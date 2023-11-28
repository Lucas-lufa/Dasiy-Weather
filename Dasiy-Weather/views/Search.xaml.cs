namespace Dasiy_Weather.views;

public partial class Search : ContentPage
{
    APIService service;
    LocationWeather weatherdata;
    public Search()
	{
		InitializeComponent();
        service = ((App)Application.Current).Service;
        weatherdata = ((App)Application.Current).WeatherData;
        locationList.ItemsSource = " . . . . ".ToString().Split('.').ToList();
    }

	private async void getCity_Clicked(object sender, EventArgs e)
    {
        service.savedLocation = null;
        service.city = locationSearch.Text;
        List<APIService.Location> locations = await service.GetLocation(service.city);
        service.savedLocations = locations;
        locationList.ItemsSource = locations;
    }

    private async void locationList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        { 
        APIService.Location location = (APIService.Location)locationList.SelectedItem;
            //APIService.Location savedLocation = location;
            service.savedLocation = location;
            string URL = service.createURL(location);
        weatherdata = await service.GetLocationWeather(URL);

        //locationSearch.Text
        locationList.ItemsSource = weatherdata.ToString().Split(',').ToList();
        }
        catch (Exception ex) 
        {
            locationList.ItemsSource = service.savedLocations;
        }
    }

    private void savePrefrence_Clicked(object sender, EventArgs e)
    {
        if (service.savedLocation == null) 
        { 
            return; 
        }
        else 
        {
            Preferences.Set("fav", service.createURL(service.savedLocation));
            Preferences.Set("favName", $"{weatherdata.name} {weatherdata.sys.country}");
        }
    }

    protected override async void OnAppearing()
    {
        favWeather.Text = await service.displayFav();
    }

    private async void weatherDetails_Clicked(object sender, EventArgs e)
    {
        //Application.Current.MainPage.Navigation.PushModalAsync(new WeatherDetails(), true);

        WeatherDetails weatherdetails = new WeatherDetails();
        await Navigation.PushModalAsync(weatherdetails);
    }

    
}