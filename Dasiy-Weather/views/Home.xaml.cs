namespace Dasiy_Weather.views;

public partial class Home : ContentPage
{
    APIService service;
    LocationWeather weatherdata;
    public Home()
	{
		InitializeComponent();
        service = ((App)Application.Current).Service;
        weatherdata = ((App)Application.Current).WeatherData;
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
        weatherdata = await service.GetLocationWeather(URL);
		output.Text = weatherdata.ToString();
        }
    }

    private void changeScreen()
	{
        Application.Current.MainPage.Navigation.PushModalAsync(new Search(), true);
        //https://jinoh.co/net-maui-adding-a-new-page-and-redirect/
    }

    private void updateOutputText(string text)
    {
        output.Text = text;
    }
}