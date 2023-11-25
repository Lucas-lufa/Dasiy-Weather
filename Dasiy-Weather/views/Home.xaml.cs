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
    }


    protected override async void OnAppearing()
    {
        //base.OnAppearing();
        output.Text = await service.displayFav(weatherdata);
    }

}