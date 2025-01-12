

using Biz.Dtos;
using Biz.Interfaces;
using Biz.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace MainApp.ViewModels;

public partial class UserDetailsViewModel(IUserService userService, IServiceProvider serviceProvider) : ObservableObject
{
    
    private readonly IUserService _userService = userService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private User _user = new();
    
    [RelayCommand]
    private void EditUser()
    {
        var userEditViewModel = _serviceProvider.GetRequiredService<UserEditViewModel>();
        userEditViewModel.User = User;
        
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = userEditViewModel;
        
    }
    [RelayCommand]
    private void Delete()
    {
        var urf = new UserRegForm();

        bool result = _userService.Delete(User.Id, urf);
        if (result)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<UserListViewModel>();
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<UserListViewModel>();
    }
}
