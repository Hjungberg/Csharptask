

using Biz.Dtos;
using Biz.Interfaces;
using Biz.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace MainApp.ViewModels;

public partial class UserEditViewModel(IUserService userService, IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IUserService _userService = userService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;


    [ObservableProperty]
    private User _user = new();
    

    [RelayCommand]
    private void Edit()
    {
        var urf = new UserRegForm();
        urf.FirstName = User.FirstName;
        urf.LastName = User.LastName;
        urf.Address = User.Address;  
        urf.PostCode = User.PostCode;  
        urf.City = User.City;  
        urf.Phone = User.Phone;  
        urf.Email = User.Email;


        bool result = _userService.Edit(User.Id, urf);
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
