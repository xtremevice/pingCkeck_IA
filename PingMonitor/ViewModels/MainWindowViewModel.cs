using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PingMonitor.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<PingSiteViewModel> _sites;

    [ObservableProperty]
    private string _newSiteUrl = string.Empty;

    [ObservableProperty]
    private int _pingInterval = 1000;

    public MainWindowViewModel()
    {
        _sites = new ObservableCollection<PingSiteViewModel>();
    }

    [RelayCommand]
    private void AddSite()
    {
        if (!string.IsNullOrWhiteSpace(NewSiteUrl))
        {
            var site = new PingSiteViewModel(NewSiteUrl.Trim(), PingInterval);
            Sites.Add(site);
            NewSiteUrl = string.Empty;
        }
    }

    [RelayCommand]
    private void RemoveSite(PingSiteViewModel site)
    {
        if (site != null)
        {
            site.Stop();
            Sites.Remove(site);
        }
    }

    [RelayCommand]
    private void UpdateInterval()
    {
        foreach (var site in Sites)
        {
            site.UpdateInterval(PingInterval);
        }
    }

    [RelayCommand]
    private async Task GenerateReport()
    {
        if (!Sites.Any())
            return;

        var sb = new StringBuilder();
        sb.AppendLine("Ping Monitor Report");
        sb.AppendLine($"Generated: {System.DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        sb.AppendLine(new string('=', 80));
        sb.AppendLine();

        foreach (var site in Sites)
        {
            sb.AppendLine($"Site: {site.Url}");
            sb.AppendLine($"Current Status: {(site.IsOnline ? "Online" : "Offline")}");
            sb.AppendLine($"Last Ping: {site.LastPingMs} ms");
            sb.AppendLine($"Average (50): {site.AveragePing50:F2} ms");
            sb.AppendLine($"Maximum: {site.MaxPingMs} ms");
            sb.AppendLine();
            sb.AppendLine("Last 100 Ping Results:");
            sb.AppendLine("Timestamp                | Ping Time (ms) | Status");
            sb.AppendLine(new string('-', 80));

            var history = site.GetPingHistory100();
            foreach (var result in history)
            {
                var status = result.IsSuccess ? "Success" : "Failed";
                var pingTime = result.IsSuccess ? result.PingTimeMs.ToString() : "N/A";
                sb.AppendLine($"{result.Timestamp:yyyy-MM-dd HH:mm:ss} | {pingTime,14} | {status}");
            }

            sb.AppendLine();
            sb.AppendLine(new string('=', 80));
            sb.AppendLine();
        }

        // Save to file
        var fileName = $"PingReport_{System.DateTime.Now:yyyyMMdd_HHmmss}.txt";
        var desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        var filePath = Path.Combine(desktopPath, fileName);

        await File.WriteAllTextAsync(filePath, sb.ToString());

        // Note: In a real application, you might want to show a dialog to the user
        // For now, we'll just write to the desktop
    }

    public void Cleanup()
    {
        foreach (var site in Sites.ToList())
        {
            site.Stop();
        }
        Sites.Clear();
    }
}
