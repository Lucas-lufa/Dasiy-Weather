namespace Dasiy_Weather.views;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
		displayFav();
    }

	private async void displayFav()
	{
        string URL = Preferences.Default.Get("fav", "to-deside");
        LocationWeather locationWeather = await APIService.GetLocationWeather(URL);
		output.Text = locationWeather.ToString();
    }
}