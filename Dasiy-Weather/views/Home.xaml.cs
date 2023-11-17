namespace Dasiy_Weather.views;

public partial class Home : ContentPage
{
	APIService service = new APIService();
	public Home()
	{
		InitializeComponent();
		displayFav();
    }

	private async void displayFav()
	{
        string URL = Preferences.Default.Get("fav", "to-deside");
        LocationWeather locationWeather = await service.GetLocationWeather(URL);
		output.Text = locationWeather.ToString();
    }
}