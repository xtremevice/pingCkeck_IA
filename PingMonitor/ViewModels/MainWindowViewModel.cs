using System.Collections.ObjectModel;
using System.Linq;
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

    public void Cleanup()
    {
        foreach (var site in Sites.ToList())
        {
            site.Stop();
        }
        Sites.Clear();
    }
}
