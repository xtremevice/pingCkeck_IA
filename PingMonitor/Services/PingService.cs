using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using PingMonitor.Models;

namespace PingMonitor.Services;

public class PingService
{
    private CancellationTokenSource? _cancellationTokenSource;
    private Task? _pingTask;

    public event Action<PingSiteModel>? PingResultReceived;

    public void StartPinging(PingSiteModel site, int intervalMs)
    {
        StopPinging();

        _cancellationTokenSource = new CancellationTokenSource();
        var token = _cancellationTokenSource.Token;

        _pingTask = Task.Run(async () =>
        {
            using var pinger = new Ping();
            
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var reply = await pinger.SendPingAsync(site.Url, 5000);
                    
                    if (reply.Status == IPStatus.Success)
                    {
                        site.IsOnline = true;
                        site.AddPingResult(reply.RoundtripTime);
                    }
                    else
                    {
                        site.MarkAsOffline();
                    }

                    PingResultReceived?.Invoke(site);
                }
                catch (Exception)
                {
                    site.MarkAsOffline();
                    PingResultReceived?.Invoke(site);
                }

                try
                {
                    await Task.Delay(intervalMs, token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
            }
        }, token);
    }

    public void StopPinging()
    {
        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }

        _pingTask = null;
    }
}
