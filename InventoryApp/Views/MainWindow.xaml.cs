using InventoryApp.ViewModels;
using InventoryApp.Views;
using System.Windows;

namespace InventoryApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var vm = new MainViewModel();
        vm.LogoutRequested += OnLogoutRequested;
        DataContext = vm;
    }

    private void OnLogoutRequested()
    {
        var loginWindow = new LoginWindow();
        loginWindow.Show();
        Close();
    }
}