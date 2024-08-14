using Microsoft.UI.Xaml.Data;

namespace UnoNativationTest.Presentation;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;

    [ObservableProperty]
    private string? name;

    [ObservableProperty]
    private int _count = 0;

    [ObservableProperty]
    private int _step = 1;

    [ObservableProperty]
    private float _celsius = 20;

    [ObservableProperty]
    private float _kilograms = 10;

    [RelayCommand]
    private void Increment()
        => Count += Step;

    [ObservableProperty]
    private List<String> _fonts = ["Arial","Comic Sans MS","Courier New","Segoe UI","Times New Roman"];

    [ObservableProperty]
    private String _selectedFont;


    public MainViewModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _selectedFont = _fonts[2];

        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
        GoToSecond = new AsyncRelayCommand(GoToSecondView);
    }
    public string? Title { get; }

    public ICommand GoToSecond { get; }

    private async Task GoToSecondView()
    {
        await _navigator.NavigateViewModelAsync<SecondViewModel>(this, data: new Entity(Name!));
    }
}
