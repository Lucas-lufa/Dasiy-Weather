namespace Dasiy_Weather.views;

public partial class Search : ContentPage
{
	public Search()
	{
		InitializeComponent();
    }

	private async void getCity_Clicked(object sender, EventArgs e)
    {
        APIService.savedLocation = null;
        APIService.city = locationSearch.Text;
        List<APIService.Location> locations = await APIService.GetLocation(APIService.city);
        APIService.savedLocations = locations;
        locationList.ItemsSource = locations;
        
    }

    private async void locationList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        { 
        APIService.Location location = (APIService.Location)locationList.SelectedItem;
            APIService.Location savedLocation = location;


        LocationWeather locationWeather = await APIService.GetLocationWeather(location);

        //locationSearch.Text
        locationList.ItemsSource = locationWeather.ToString().Split(',').ToList();
        }
        catch (Exception ex) 
        {
            locationList.ItemsSource = APIService.savedLocations;
        }
    }
}