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

        if (DataPoints == null || !DataPoints.Any())
            return;

        var points = DataPoints.ToList();
        if (points.Count == 0)
            return;

        var width = Bounds.Width;
        var height = Bounds.Height;
        var maxValue = points.Max();
        
        if (maxValue == 0)
            maxValue = 1;

        var pointBrush = Brushes.DodgerBlue;
        var pointRadius = 3.0;

        // Calculate point spacing
        var pointSpacing = points.Count > 1 ? width / (points.Count - 1) : width / 2;

        // Draw scatter points
        for (int i = 0; i < points.Count; i++)
        {
            var x = i * pointSpacing;
            var y = height - (points[i] / maxValue * height);
            
            // Draw circle for each point
            context.DrawEllipse(pointBrush, null, new Point(x, y), pointRadius, pointRadius);
        }
    }
}
