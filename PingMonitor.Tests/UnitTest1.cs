using PingMonitor.Models;
using Xunit;

namespace PingMonitor.Tests;

public class PingSiteModelTests
{
    [Fact]
    public void AddPingResult_UpdatesLastPing()
    {
        // Arrange
        var site = new PingSiteModel { Url = "test.com" };

        // Act
        site.AddPingResult(50);

        // Assert
        Assert.Equal(50, site.LastPingMs);
        Assert.True(site.IsOnline);
    }

    [Fact]
    public void AddPingResult_UpdatesMaxPing()
    {
        // Arrange
        var site = new PingSiteModel { Url = "test.com" };

        // Act
        site.AddPingResult(50);
        site.AddPingResult(100);
        site.AddPingResult(75);

        // Assert
        Assert.Equal(100, site.MaxPingMs);
    }

    [Fact]
    public void AddPingResult_CalculatesAverage()
    {
        // Arrange
        var site = new PingSiteModel { Url = "test.com" };

        // Act
        site.AddPingResult(50);
        site.AddPingResult(100);
        site.AddPingResult(150);

        // Assert
        Assert.Equal(100.0, site.AveragePing50);
    }

    [Fact]
    public void AddPingResult_LimitsHistoryTo50()
    {
        // Arrange
        var site = new PingSiteModel { Url = "test.com" };

        // Act
        for (int i = 0; i < 60; i++)
        {
            site.AddPingResult(i);
        }

        // Assert
        Assert.Equal(50, site.PingHistory.Count);
    }

    [Fact]
    public void MarkAsOffline_SetsCorrectState()
    {
        // Arrange
        var site = new PingSiteModel { Url = "test.com" };
        site.AddPingResult(50);

        // Act
        site.MarkAsOffline();

        // Assert
        Assert.False(site.IsOnline);
        Assert.Equal(-1, site.LastPingMs);
    }
}
