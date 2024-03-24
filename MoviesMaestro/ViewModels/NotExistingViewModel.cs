using CommunityToolkit.Mvvm.ComponentModel;

namespace MoviesMaestro.ViewModels
{
    public partial class NotExistingViewModel : ViewModelBase
    {
        [ObservableProperty]
        public string? _error;
    }
}