using CommunityToolkit.Mvvm.ComponentModel;

namespace MoviesMaestro.ViewModels
{
    public partial class NotExisting : ViewModelBase
    {
        [ObservableProperty]
        public string? _error;
    }
}