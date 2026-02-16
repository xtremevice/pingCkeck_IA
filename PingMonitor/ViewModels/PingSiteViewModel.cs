using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using PingMonitor.Models;
using PingMonitor.Services;

namespace PingMonitor.ViewModels;

public partial class PingSiteViewModel : ViewModelBase
{
    private readonly PingSiteModel _model;
    private readonly PingService _pingService;

    [ObservableProperty]
    private string _url;

    [ObservableProperty]
    private long _lastPingMs;

    [ObservableProperty]
    private long _maxPingMs;

    [ObservableProperty]
    private double _averagePing50;

    [ObservableProperty]
    private bool _isOnline;

    [ObservableProperty]
    private string _statusText;

    [ObservableProperty]
    private ObservableCollection<double> _pingHistoryPoints;

    public PingSiteViewModel(string url, int pingIntervalMs)
    {
        _url = url;
        _model = new PingSiteModel { Url = url };
        _pingService = new PingService();
        _statusText = "Waiting...";
        _pingHistoryPoints = new ObservableCollection<double>();

        _pingService.PingResultReceived += OnPingResultReceived;
        _pingService.StartPinging(_model, pingIntervalMs);
    }

    private void OnPingResultReceived(PingSiteModel site)
    {
        // Update UI on UI thread
        Avalonia.Threading.Dispatcher.UIThread.Post(() =>
        {
            LastPingMs = site.LastPingMs;
            MaxPingMs = site.MaxPingMs;
            AveragePing50 = site.AveragePing50;
            IsOnline = site.IsOnline;
            StatusText = site.IsOnline ? $"{site.LastPingMs} ms" : "Offline";

            // Update history points for graph
            PingHistoryPoints.Clear();
            foreach (var ping in site.PingHistory)
            {
                PingHistoryPoints.Add(ping);
            }
        });
    }

    public void UpdateInterval(int newIntervalMs)
    {
        _pingService.StartPinging(_model, newIntervalMs);
    }

    public void Stop()
    {
        _pingService.StopPinging();
    }
}
