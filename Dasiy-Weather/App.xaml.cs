namespace Dasiy_Weather;

public partial class App : Application
{
	public APIService Service { get; set; } = new();
	public LocationWeather WeatherData { get; set; } = new();
    public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
		Service.lightORdark();
	}
}
