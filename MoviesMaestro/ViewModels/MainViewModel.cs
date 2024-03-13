
using Avalonia.SimpleRouter;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentAvalonia.UI.Controls;
using MoviesMaestro.Models;
using MoviesMaestro.Views;
using System;
using System.Collections.ObjectModel;

namespace MoviesMaestro.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage = default!;

    [ObservableProperty]
    private NavigationViewItemTemplate _actualPage;

    partial void OnActualPageChanged(NavigationViewItemTemplate actualPage)
    {
        switch (actualPage.Tag)
        {
            case "HomeViewModel":
                _router.GoTo<HomeViewModel>();
                break;
            case "SettingsViewModel":
                _router.GoTo<SettingsViewModel>();
                break;

        }
    }


    public ObservableCollection<NavigationViewItemTemplate> NavigationItems { get; set; } = new()
    {
        new NavigationViewItemTemplate("Home", "Home", nameof(HomeViewModel)),
    };

    public MainViewModel(Router<ViewModelBase> router)
    {
        _router = router;
        _router.CurrentViewModelChanged += _router_CurrentViewModelChanged;
        _router.GoTo<HomeViewModel>();
    }

    private void _router_CurrentViewModelChanged(ViewModelBase obj)
    {
        CurrentPage = obj;
    }

    private readonly Router<ViewModelBase> _router;
}

