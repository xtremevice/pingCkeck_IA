using System;
using System.Collections.Generic;

namespace PingMonitor.Models;

public class PingSiteModel
{
    public string Url { get; set; } = string.Empty;
    public long LastPingMs { get; set; }
    public long MaxPingMs { get; set; }
    public double AveragePing50 { get; set; }
    public Queue<long> PingHistory { get; set; } = new Queue<long>(50);
    public bool IsOnline { get; set; }
    public DateTime LastPingTime { get; set; }

    public void AddPingResult(long pingTimeMs)
    {
        LastPingMs = pingTimeMs;
        LastPingTime = DateTime.Now;
        
        if (pingTimeMs > MaxPingMs)
        {
            MaxPingMs = pingTimeMs;
        }

        PingHistory.Enqueue(pingTimeMs);
        if (PingHistory.Count > 50)
        {
            PingHistory.Dequeue();
        }

        // Calculate average of last 50 pings
        long sum = 0;
        foreach (var ping in PingHistory)
        {
            sum += ping;
        }
        AveragePing50 = PingHistory.Count > 0 ? (double)sum / PingHistory.Count : 0;
    }

    public void MarkAsOffline()
    {
        IsOnline = false;
        LastPingMs = -1;
        LastPingTime = DateTime.Now;
    }
}
