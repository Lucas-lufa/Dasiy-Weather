namespace Dasiy_Weather.views;

public partial class Home : ContentPage
{
    APIService service;

    private int temperatureGridLength { get; set; }
    private Border minTemp = new();

    float offset;
    float unit;
    float lowerBounds;
    float tempBounds;
    float upperBounds;
    float segment;
    float minPadding;
    float tempPadding;
    float maxPadding;

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

        offset = 5;
        unit = 200;
        lowerBounds = service.savedWeather.main.temp_min - offset;
        tempBounds = service.savedWeather.main.temp;
        upperBounds = service.savedWeather.main.temp_max + offset;
        segment = (upperBounds - lowerBounds) / unit;
        minPadding = offset * segment;
        tempPadding = tempBounds * segment - minPadding;
        maxPadding = service.savedWeather.main.temp_max * segment - minPadding;
    }

    private void setUpVisulation() 
    {
        float unit = 200;
        float offset = 5;
        float lowerBounds = service.savedWeather.main.temp_min - offset;
        float tempBounds = service.savedWeather.main.temp;
        float upperBounds = service.savedWeather.main.temp_max + offset;
        float segment = (upperBounds - lowerBounds) / unit;
        float minPadding = offset * segment;
        float tempPadding = tempBounds * segment - minPadding;
        float maxPadding = service.savedWeather.main.temp_max * segment - minPadding;
    }

    protected override async void OnAppearing()
    {
        //base.OnAppearing();
        output.Text = await service.displayFav(service.iconBig);
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



