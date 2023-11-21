namespace Dasiy_Weather.views;

public partial class Settings : ContentPage
{
    APIService service;
    LocationWeather weatherdata;
    public Settings()
	{
		InitializeComponent();
        service = ((App)Application.Current).Service;
        weatherdata = ((App)Application.Current).WeatherData;
	}

	private void updatePreferenceLable()
	{
		whatsInPreference.Text = Preferences.Default.Get("favName", "No Saved Location.");
	}
    private void Clear_Clicked(object sender, EventArgs e)
    {
		Preferences.Clear();
		updatePreferenceLable();
		
    }

    protected override void OnAppearing()
    {
        //base.OnAppearing();
        updatePreferenceLable();
    }
}