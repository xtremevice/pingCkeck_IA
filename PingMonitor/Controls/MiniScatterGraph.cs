using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PingMonitor.Controls;

public class MiniScatterGraph : Control
{
    public static readonly StyledProperty<IEnumerable<double>> DataPointsProperty =
        AvaloniaProperty.Register<MiniScatterGraph, IEnumerable<double>>(nameof(DataPoints));

    public IEnumerable<double> DataPoints
    {
        get => GetValue(DataPointsProperty);
        set => SetValue(DataPointsProperty, value);
    }

    static MiniScatterGraph()
    {
        AffectsRender<MiniScatterGraph>(DataPointsProperty);
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

        var maxValue = points.Max();
        
        if (maxValue == 0)
            maxValue = 1;

        var pointBrush = Brushes.DodgerBlue;
        var pointRadius = 4.0;

        // Add padding
        var padding = 5.0;
        var graphWidth = width - (padding * 2);
        var graphHeight = height - (padding * 2);

        // Calculate point spacing
        var pointSpacing = points.Count > 1 ? graphWidth / (points.Count - 1) : graphWidth / 2;

        // Draw scatter points
        for (int i = 0; i < points.Count; i++)
        {
            var x = padding + (i * pointSpacing);
            var y = padding + (graphHeight - (points[i] / maxValue * graphHeight));
            
            // Draw circle for each point with a white outline
            context.DrawEllipse(pointBrush, new Pen(Brushes.White, 1), new Point(x, y), pointRadius, pointRadius);
        }
    }
}
