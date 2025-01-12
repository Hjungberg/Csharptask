

using Biz.Interfaces;
using Biz.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace MainApp.ViewModels;

public partial class UserListViewModel : ObservableObject
{
    private readonly IUserService _userService;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private ObservableCollection<User> _users = [];

    public UserListViewModel(IUserService userService, IServiceProvider serviceProvider)
    {
        _userService = userService;
        _serviceProvider = serviceProvider;

        _users = new ObservableCollection<User>(_userService.GetAll());
        
            
    }

    [RelayCommand]
    private void GoToAddView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<UserAddViewModel>();
    }

    [RelayCommand]
    private void GoToDetailsView(User user)
    {
        var userDetailsViewModel = _serviceProvider.GetRequiredService<UserDetailsViewModel>();
        userDetailsViewModel.User = user;
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = userDetailsViewModel;
    }
}
