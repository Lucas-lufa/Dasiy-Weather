namespace Dasiy_Weather.views;

public partial class Home : ContentPage
{
    APIService service;

    private int temperatureGridLength { get; set; }
    private Border minTemp = new();

    float offset = 5;
    float unit = 200;
    float lowerBounds;
    float upperBounds;
    float rangeBound;
    float tempBounds;
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
        
    }


    protected override async void OnAppearing()
    {
        //base.OnAppearing();
        output.Text = await service.displayFav(service.iconBig);
        
        if (service.savedWeather != null) { 
        outputCity.Text = $"{service.savedWeather.name} {service.savedWeather.sys.country}";
        homeIcon.Source = service.IconAPICall;
        //double unit = 200;
        //double minPadding = 4 * (service.savedWeather.main.temp_min);
        //double tempPadding = (4 * (service.savedWeather.main.temp)) - minPadding;
        //double maxPadding = (4 * (service.savedWeather.main.temp_max)) - minPadding - tempPadding;
        lowerBounds = service.savedWeather.main.temp_min - offset;
        upperBounds = service.savedWeather.main.temp_max + offset;
        rangeBound = upperBounds - lowerBounds;
        tempBounds = service.savedWeather.main.temp - lowerBounds;
        segment = unit / rangeBound;
        minPadding = offset * segment;
        tempPadding = (service.savedWeather.main.temp - service.savedWeather.main.temp_min ) * segment ;
        maxPadding = (service.savedWeather.main.temp_max - service.savedWeather.main.temp) * segment ;

        tempDisplay.WidthRequest = unit;
        min.WidthRequest = minPadding;
        temp.WidthRequest = tempPadding;
        max.WidthRequest = maxPadding;
        }

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

    //private void setUpVisulation() 
    //{
    //    float unit = 200;
    //    float offset = 5;
    //    float lowerBounds = service.savedWeather.main.temp_min - offset;
    //    float tempBounds = service.savedWeather.main.temp;
    //    float upperBounds = service.savedWeather.main.temp_max + offset;
    //    float segment = (upperBounds - lowerBounds) / unit;
    //    float minPadding = offset * segment;
    //    float tempPadding = tempBounds * segment - minPadding;
    //    float maxPadding = service.savedWeather.main.temp_max * segment - minPadding;
    //}


