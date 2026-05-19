using InventoryApp.Data;
using InventoryApp.Data.Repositories;
using InventoryApp.Services;
using InventoryApp.Views;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace InventoryApp;

public partial class App : Application
{
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // OnExplicitShutdown is set in App.xaml so that closing LoginWindow
        // after opening MainWindow (or vice-versa) does not terminate the process.
        // We call Shutdown() explicitly only on error or when the last window closes via logout.
        try
        {
            // Create inventory.db and all tables on first run
            using var ctx = new AppDbContext();
            await ctx.Database.EnsureCreatedAsync();

            // Seed admin account when the Users table is empty
            if (!await ctx.Users.AnyAsync())
                await new AuthService(new UserRepository())
                    .RegisterAsync("admin", "admin@inventory.com", "Admin@123", "Admin");

            new LoginWindow().Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to start application:\n\n{ex.Message}",
                "Startup Error", MessageBoxButton.OK, MessageBoxImage.Error);
            Shutdown(1);
        }
    }
}