namespace Dasiy_Weather.views;

public partial class Search : ContentPage
{
    APIService service = new();
    LocationWeather locationWeather = new();
    public Search()
	{
		InitializeComponent();

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
        locationWeather = await service.GetLocationWeather(URL);

        //locationSearch.Text
        locationList.ItemsSource = locationWeather.ToString().Split(',').ToList();
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
            Preferences.Default.Set("fav", service.createURL(service.savedLocation));
            Preferences.Default.Set("favName", $"{locationWeather.name} {locationWeather.sys.country}");
        }

    }
}