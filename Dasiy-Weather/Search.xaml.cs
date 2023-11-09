namespace Dasiy_Weather.views;

public partial class Search : ContentPage
{
	public Search()
	{
		InitializeComponent();
        
    }

	private async void getCity_Clicked(object sender, EventArgs e)
    {
        string city = locationSearch.Text;
        List<APIService.Location> locations = await APIService.GetLocation(city);
        locationList.ItemsSource = locations;
        
        
        //locationList.ItemsSource = locations.Select(item => $"{item.name} {item.state} {item.country}");

    }

    private async void locationList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        APIService.Location location = (APIService.Location)locationList.SelectedItem;
        
        
        LocationWeather locationWeather = await APIService.GetLocationWeather(location);

        locationSearch.Text = locationWeather.main.ToString();
    }
}