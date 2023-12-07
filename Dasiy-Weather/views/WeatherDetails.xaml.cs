namespace Dasiy_Weather.views;

public partial class WeatherDetails : ContentPage
{
    APIService service;
    LocationWeather weatherdata;
    public WeatherDetails()
	{
		InitializeComponent();
        service = ((App)Application.Current).Service;
        weatherdata = ((App)Application.Current).WeatherData;

        if (service.savedWeather != null ) 
        {        
        detailCityName.Text = $"City: {service.savedWeather.name}";
        temp.Text = $"Temperature:  {service.savedWeather.main.temp}";
        feels_like.Text = $"Feels like: {service.savedWeather.main.feels_like}";
        temp_min.Text = $"Temperature min: {service.savedWeather.main.temp_min}";
        temp_max.Text = $"Temperature max: {service.savedWeather.main.temp_max}";
        pressure.Text = $"Pressure: {service.savedWeather.main.pressure}";
        humidity.Text = $"Humidity: {service.savedWeather.main.humidity}";
        }
        else
        {
            detailCityName.Text = "Search and save to add a city to show the weather";
            feels_like.Text = "";
            temp.Text = "";
            temp_min.Text = "";
            temp_max.Text = "";
            pressure.Text = "";
            humidity.Text = "";
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}