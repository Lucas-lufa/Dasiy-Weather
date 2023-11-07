namespace Dasiy_Weather.views;

public partial class Search : ContentPage
{
	public Search()
	{
		InitializeComponent();
        
    }

	private async void getCity_Clicked(object sender, EventArgs e)
    {
        APIService service = new();
        string city = locationSearch.Text;
        List<APIService.Location> locations = await service.GetLocation(city);
        locationList.ItemsSource = locations;
        
        
        //locationList.ItemsSource = locations.Select(item => $"{item.name} {item.state} {item.country}");

    }

    private void locationList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        APIService.Location location = (APIService.Location)locationList.SelectedItem;
        string lat = location.lat.ToString();
        string lon = location.lon.ToString();

    }
}