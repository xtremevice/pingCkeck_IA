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

        if (DataPoints == null || !DataPoints.Any())
            return;

        var points = DataPoints.ToList();
        if (points.Count < 2)
            return;

        var width = Bounds.Width;
        var height = Bounds.Height;
        var maxValue = points.Max();
        
        if (maxValue == 0)
            maxValue = 1;

        var pen = new Pen(Brushes.LightBlue, 2);
        var fillBrush = new SolidColorBrush(Color.FromArgb(50, 173, 216, 230));

        var pointWidth = width / Math.Max(points.Count - 1, 1);

        // Create polyline for the graph
        var polylinePoints = new List<Point>();
        
        for (int i = 0; i < points.Count; i++)
        {
            var x = i * pointWidth;
            var y = height - (points[i] / maxValue * height);
            polylinePoints.Add(new Point(x, y));
        }

        // Draw filled area
        var fillPoints = new List<Point>(polylinePoints);
        fillPoints.Add(new Point(width, height));
        fillPoints.Add(new Point(0, height));
        
        var geometry = new PolylineGeometry(fillPoints, true);
        context.DrawGeometry(fillBrush, null, geometry);

        // Draw line
        for (int i = 0; i < polylinePoints.Count - 1; i++)
        {
            context.DrawLine(pen, polylinePoints[i], polylinePoints[i + 1]);
        }
    }
}
