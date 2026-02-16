using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PingMonitor.Controls;

public class MiniPingGraph : Control
{
    public static readonly StyledProperty<IEnumerable<double>> DataPointsProperty =
        AvaloniaProperty.Register<MiniPingGraph, IEnumerable<double>>(nameof(DataPoints));

    public IEnumerable<double> DataPoints
    {
        get => GetValue(DataPointsProperty);
        set => SetValue(DataPointsProperty, value);
    }

    static MiniPingGraph()
    {
        AffectsRender<MiniPingGraph>(DataPointsProperty);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        var width = Bounds.Width;
        var height = Bounds.Height;

        // Draw background
        context.DrawRectangle(new SolidColorBrush(Color.FromRgb(250, 250, 250)), null, new Rect(0, 0, width, height));
        
        // Draw border
        context.DrawRectangle(null, new Pen(Brushes.LightGray, 1), new Rect(0, 0, width, height));

        if (DataPoints == null || !DataPoints.Any())
        {
            // Draw "No data" message
            var typeface = new Typeface("Arial");
            var text = new FormattedText(
                "No data",
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                typeface,
                10,
                Brushes.Gray);
            context.DrawText(text, new Point((width - text.Width) / 2, (height - text.Height) / 2));
            return;
        }

        var points = DataPoints.ToList();
        if (points.Count == 0)
            return;

        // Add padding
        var padding = 5.0;
        var graphWidth = width - (padding * 2);
        var graphHeight = height - (padding * 2);

        // If only one point, draw it as a circle
        if (points.Count == 1)
        {
            var maxValue = points[0] > 0 ? points[0] : 1;
            var y = padding + (graphHeight - (points[0] / maxValue * graphHeight));
            var x = padding + (graphWidth / 2); // Center the point
            
            var pointBrush = Brushes.DodgerBlue;
            var pointRadius = 4.0;
            context.DrawEllipse(pointBrush, new Pen(Brushes.White, 1), new Point(x, y), pointRadius, pointRadius);
            return;
        }

        // For multiple points
        var maxValue2 = points.Max();
        
        if (maxValue2 == 0)
            maxValue2 = 1;

        var pen = new Pen(Brushes.LightBlue, 2);
        var fillBrush = new SolidColorBrush(Color.FromArgb(50, 173, 216, 230));

        var pointWidth = graphWidth / Math.Max(points.Count - 1, 1);

        // Create polyline for the graph
        var polylinePoints = new List<Point>();
        
        for (int i = 0; i < points.Count; i++)
        {
            var x = padding + (i * pointWidth);
            var y = padding + (graphHeight - (points[i] / maxValue2 * graphHeight));
            polylinePoints.Add(new Point(x, y));
        }

        // Draw filled area
        var fillPoints = new List<Point>(polylinePoints);
        fillPoints.Add(new Point(width - padding, height - padding));
        fillPoints.Add(new Point(padding, height - padding));
        
        var geometry = new PolylineGeometry(fillPoints, true);
        context.DrawGeometry(fillBrush, null, geometry);

        // Draw line
        for (int i = 0; i < polylinePoints.Count - 1; i++)
        {
            context.DrawLine(pen, polylinePoints[i], polylinePoints[i + 1]);
        }
    }
}
