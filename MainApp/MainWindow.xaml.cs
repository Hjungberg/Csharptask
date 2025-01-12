
using MainApp.ViewModels;
using System.Windows;

namespace MainApp;


public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}