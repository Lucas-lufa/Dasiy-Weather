namespace Dasiy_Weather.views;

public partial class Search : ContentPage
{
	public Search()
	{
		InitializeComponent();
    }

	private async void getCity_Clicked(object sender, EventArgs e)
    {
        APIService.city = locationSearch.Text;
        List<APIService.Location> locations = await APIService.GetLocation(APIService.city);
        locationList.ItemsSource = locations;
        
    }

    private async void locationList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        APIService.Location location = (APIService.Location)locationList.SelectedItem;
        
        LocationWeather locationWeather = await APIService.GetLocationWeather(location);

        //locationSearch.Text
        locationList.ItemsSource = locationWeather.ToString().Split(',').ToList();
    }
}