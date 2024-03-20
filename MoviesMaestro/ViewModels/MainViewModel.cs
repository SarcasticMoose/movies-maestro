
using Avalonia.Animation.Easings;
using Avalonia.SimpleRouter;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentAvalonia.UI.Controls;
using MoviesMaestro.Models;
using MoviesMaestro.Views;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace MoviesMaestro.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage = default!;

    [ObservableProperty]
    private NavigationViewItemTemplate? _choosenNavigationItem;

    partial void OnChoosenNavigationItemChanged(NavigationViewItemTemplate? value)
    {
        _ = value?.Tag switch
        {
            nameof(HomeViewModel) => _router?.GoTo<HomeViewModel>() as ViewModelBase,
            nameof(MoviesViewModel) => _router?.GoTo<MoviesViewModel>() as ViewModelBase,
            nameof(TvSeriesViewModel) => _router?.GoTo<TvSeriesViewModel>() as ViewModelBase,
            nameof(YourListViewModel) => _router?.GoTo<YourListViewModel>() as ViewModelBase,
            nameof(AccountViewModel) => _router?.GoTo<AccountViewModel>() as ViewModelBase,
            nameof(SettingsViewModel) => _router?.GoTo<SettingsViewModel>() as ViewModelBase,
            nameof(HelpViewModel) => _router?.GoTo<HelpViewModel>() as ViewModelBase,
            _ => _router?.GoTo<NotExisting>() as ViewModelBase,
        };

    }

    public IObservable<ViewModelBase> WhenCurrentViewModelChange
    {
        get => Observable
            .FromEvent<ViewModelBase>(h => _router!.CurrentViewModelChanged += h, h => _router!.CurrentViewModelChanged -= h)
            .Select(x => x);
    }

    public ObservableCollection<NavigationViewItemTemplate> FooterNavigationItems { get; set; } = new()
    {
        new NavigationViewItemTemplate("Account", "Account", nameof(AccountViewModel)),
        new NavigationViewItemTemplate("Setings", "Settings", nameof(SettingsViewModel)),
        new NavigationViewItemTemplate("Help", "Help", nameof(HelpViewModel)),
    };
    public ObservableCollection<NavigationViewItemTemplate> HeaderNavigationItems { get; set; } = new()
    {
        new NavigationViewItemTemplate("Home", "Home", nameof(HomeViewModel)),
        new NavigationViewItemTemplate("Movies", "Video", nameof(MoviesViewModel)),
        new NavigationViewItemTemplate("TV Series", "Video", nameof(TvSeriesViewModel)),
        new NavigationViewItemTemplate("Your List", "List", nameof(YourListViewModel)),
    };

    public MainViewModel(HistoryRouter<ViewModelBase> router)
    {
        _router = router;
        WhenCurrentViewModelChange.Subscribe(nextViewModel => CurrentPage = nextViewModel);
        _router.GoTo<HomeViewModel>();
    }


    private readonly HistoryRouter<ViewModelBase>? _router;
}

