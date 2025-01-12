using CommunityToolkit.Mvvm.ComponentModel;

namespace MainApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    
    [ObservableProperty]
    private ObservableObject _currentViewModel = null!;

}
