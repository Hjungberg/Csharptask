
using Biz.Interfaces;
using Biz.Services;
using MainApp.ViewModels;
using MainApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace MainApp
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IFileService>(new FileService(AppDomain.CurrentDomain.BaseDirectory, "user.json"));
                    services.AddSingleton<IUserService, UserService>();

                    services.AddTransient<UserListViewModel>();
                    services.AddTransient<UserAddViewModel>();
                    services.AddTransient<UserDetailsViewModel>();
                    services.AddTransient<UserEditViewModel>();

                    services.AddTransient<UserListView>();
                    services.AddTransient<UserAddView>();
                    services.AddTransient<UserDetailsView>();
                    services.AddTransient<UserEditView>();

                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<MainWindow>();

                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainViewModel = _host.Services.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _host.Services.GetRequiredService<UserListViewModel>();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }




    }
}