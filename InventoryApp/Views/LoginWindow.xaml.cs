using InventoryApp.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace InventoryApp.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        // DataContext is declared in XAML as <vm:LoginViewModel/>
    }

    // ── Login ────────────────────────────────────────────────────────────────

    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var vm = (LoginViewModel)DataContext;
        LoginButton.IsEnabled = false;
        try
        {
            if (await vm.LoginAsync(LoginPwdBox.Password))
            {
                new MainWindow().Show();
                Close();
            }
            else
            {
                LoginPwdBox.Clear();
            }
        }
        finally
        {
            LoginButton.IsEnabled = true;
        }
    }

    private void ShowRegisterPanel(object sender, MouseButtonEventArgs e)
    {
        var vm = (LoginViewModel)DataContext;
        vm.GoToRegisterCommand.Execute(null);
        // Clear password fields when switching panels
        LoginPwdBox.Clear();
        RegPwdBox.Clear();
        RegConfirmPwdBox.Clear();
    }

    // ── Register ─────────────────────────────────────────────────────────────

    private async void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        var vm = (LoginViewModel)DataContext;
        RegisterButton.IsEnabled = false;
        try
        {
            bool success = await vm.RegisterAsync(RegPwdBox.Password, RegConfirmPwdBox.Password);
            if (success)
            {
                RegPwdBox.Clear();
                RegConfirmPwdBox.Clear();
                // Brief pause so the user sees the success message, then switch to login
                await Task.Delay(1500);
                vm.GoToLoginCommand.Execute(null);
                LoginPwdBox.Clear();
            }
        }
        finally
        {
            RegisterButton.IsEnabled = true;
        }
    }

    private void ShowLoginPanel(object sender, RoutedEventArgs e)
    {
        var vm = (LoginViewModel)DataContext;
        vm.GoToLoginCommand.Execute(null);
        RegPwdBox.Clear();
        RegConfirmPwdBox.Clear();
    }
}