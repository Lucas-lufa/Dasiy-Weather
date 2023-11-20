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
		if (URL == "to-deside")
		{
            changeScreen();
        }
        else { 
        LocationWeather locationWeather = await service.GetLocationWeather(URL);
		output.Text = locationWeather.ToString();
        }
    }

    private void changeScreen()
	{
        //	Application.Current.MainPage.Navigation.PushModalAsync(new SettingsPage(), true);
        Application.Current.MainPage.Navigation.PushModalAsync(new Search(), true);
        //https://jinoh.co/net-maui-adding-a-new-page-and-redirect/
    }
}