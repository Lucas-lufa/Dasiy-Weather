namespace Dasiy_Weather.views;

public partial class Home : ContentPage
{
    APIService service;

    private int temperatureGridLength { get; set; }
    private Border minTemp = new();

    string iconAPIcall;
    public Home()
	{
		InitializeComponent();
        service = ((App)Application.Current).Service;

        //this.temperatureGridLength = (int)TemperatureGrid.Width;
        //for (int i = 0; i < 50; i++)
        //{
        //    var column = new ColumnDefinition(WidthRequest = temperatureGridLength / 50);
        //    TemperatureGrid.ColumnDefinitions.Add(column);
        // }
        

    }

    protected override async void OnAppearing()
    {
        //base.OnAppearing();
        output.Text = await service.displayFav();
        outputCity.Text = $"{service.savedWeather.name} {service.savedWeather.sys.country}";
        homeIcon.Source = service.IconAPICall;
        double unit = 200;
        double minPadding = 4 * (service.savedWeather.main.temp_min);
        double tempPadding = (4 * (service.savedWeather.main.temp)) - minPadding;
        double maxPadding = (4 * (service.savedWeather.main.temp_max)) - minPadding - tempPadding;
        tempDisplay.WidthRequest = unit;
        min.WidthRequest = minPadding;
        temp.WidthRequest = tempPadding;
        max.WidthRequest = maxPadding;
    }

    //public void SetCell(int index, Border tag)
    //{
    //    /* Call it like this...  Sets the tag in the specified tag corresponding to the temperature.
    //          SetCell(23, this.minTemp);
    //    */

    //    // TemperatureGrid.ColumnDefinitions[index]
    //    tag.SetBinding(Grid.ColumnProperty, TemperatureGrid.ColumnDefinitions[index])
        
    //}
}



