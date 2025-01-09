using Biz.Interfaces;
using Biz.Services;
using ConsolePresentation.Dialogs;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IFileService>(new FileService("user.json"));
serviceCollection.AddTransient<IUserService, UserService>();
serviceCollection.AddTransient<MenuDialogs>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var menuDialogs = serviceProvider.GetRequiredService<MenuDialogs>();

menuDialogs.MainMenu();

