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

    [ObservableProperty]
    private string _reportStatus = string.Empty;

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
        {
            ReportStatus = "No sites to report";
            return;
        }

        try
        {
            var timestamp = System.DateTime.Now;
            var desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            
            // Generate both TXT and CSV reports
            var txtFileName = $"PingReport_{timestamp:yyyyMMdd_HHmmss}.txt";
            var csvFileName = $"PingReport_{timestamp:yyyyMMdd_HHmmss}.csv";
            var txtFilePath = Path.Combine(desktopPath, txtFileName);
            var csvFilePath = Path.Combine(desktopPath, csvFileName);

            // Generate TXT report
            var txtContent = GenerateTxtReport();
            await File.WriteAllTextAsync(txtFilePath, txtContent);

            // Generate CSV report
            var csvContent = GenerateCsvReport();
            await File.WriteAllTextAsync(csvFilePath, csvContent);

            ReportStatus = $"Reports saved to Desktop:\n{txtFileName}\n{csvFileName}";
        }
        catch (System.Exception ex)
        {
            ReportStatus = $"Error saving report: {ex.Message}";
        }
    }

    private string GenerateTxtReport()
    {
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

        return sb.ToString();
    }

    private string GenerateCsvReport()
    {
        var sb = new StringBuilder();
        
        // CSV Header
        sb.AppendLine("Site,Timestamp,Ping Time (ms),Status,Current Status,Last Ping,Average (50),Maximum");

        foreach (var site in Sites)
        {
            var currentStatus = site.IsOnline ? "Online" : "Offline";
            var history = site.GetPingHistory100();
            
            foreach (var result in history)
            {
                var status = result.IsSuccess ? "Success" : "Failed";
                var pingTime = result.IsSuccess ? result.PingTimeMs.ToString() : "";
                
                sb.AppendLine($"{site.Url},{result.Timestamp:yyyy-MM-dd HH:mm:ss},{pingTime},{status},{currentStatus},{site.LastPingMs},{site.AveragePing50:F2},{site.MaxPingMs}");
            }
        }

        return sb.ToString();
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
