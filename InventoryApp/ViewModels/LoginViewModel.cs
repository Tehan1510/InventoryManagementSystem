using InventoryApp.Data.Repositories;
using InventoryApp.Services;

namespace InventoryApp.ViewModels;

public class LoginViewModel : BaseViewModel
{
    // ── Shared ───────────────────────────────────────────
    private bool _isRegistering;
    private bool _isLoading;

    public bool IsRegistering { get => _isRegistering; set => SetProperty(ref _isRegistering, value); }
    public bool IsNotLoading => !IsLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set { SetProperty(ref _isLoading, value); OnPropertyChanged(nameof(IsNotLoading)); }
    }

    // ── Login ────────────────────────────────────────────
    private string _username = string.Empty;
    private string _loginError = string.Empty;

    public string Username    { get => _username;    set => SetProperty(ref _username, value); }
    public string LoginError  { get => _loginError;  set => SetProperty(ref _loginError, value); }

    // ── Register ─────────────────────────────────────────
    private string _regUsername = string.Empty;
    private string _regEmail    = string.Empty;
    private string _regError    = string.Empty;
    private string _regSuccess  = string.Empty;

    public string RegUsername { get => _regUsername; set => SetProperty(ref _regUsername, value); }
    public string RegEmail    { get => _regEmail;    set => SetProperty(ref _regEmail, value); }
    public string RegError    { get => _regError;    set => SetProperty(ref _regError, value); }
    public string RegSuccess  { get => _regSuccess;  set => SetProperty(ref _regSuccess, value); }

    public RelayCommand GoToRegisterCommand { get; }
    public RelayCommand GoToLoginCommand    { get; }

    public LoginViewModel()
    {
        GoToRegisterCommand = new RelayCommand(() => { IsRegistering = true;  ClearRegisterForm(); });
        GoToLoginCommand    = new RelayCommand(() => { IsRegistering = false; ClearLoginForm(); });
    }

    public async Task<bool> LoginAsync(string password)
    {
        LoginError = string.Empty;
        IsLoading  = true;
        try
        {
            var (success, message, user) =
                await new AuthService(new UserRepository()).LoginAsync(Username, password);
            if (success && user is not null) { SessionManager.Login(user); return true; }
            LoginError = message;
            return false;
        }
        finally { IsLoading = false; }
    }

    public async Task<bool> RegisterAsync(string password, string confirmPassword)
    {
        RegError = RegSuccess = string.Empty;

        if (string.IsNullOrWhiteSpace(RegUsername)) { RegError = "Username is required.";               return false; }
        if (string.IsNullOrWhiteSpace(password))    { RegError = "Password is required.";               return false; }
        if (password != confirmPassword)             { RegError = "Passwords do not match.";             return false; }
        if (password.Length < 6)                    { RegError = "Password must be at least 6 characters."; return false; }

        IsLoading = true;
        try
        {
            var (success, message) = await new AuthService(new UserRepository())
                .RegisterAsync(RegUsername.Trim(), RegEmail.Trim(), password);
            if (success) { RegSuccess = "Account created! Taking you to sign in..."; return true; }
            RegError = message;
            return false;
        }
        finally { IsLoading = false; }
    }

    private void ClearRegisterForm() => RegUsername = RegEmail = RegError = RegSuccess = string.Empty;
    private void ClearLoginForm()    => Username = LoginError = string.Empty;
}
