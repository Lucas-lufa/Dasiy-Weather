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
        metericORimperial.IsToggled = Preferences.Get("metericORimperial", false);
        lightORdark.IsToggled = Preferences.Get("lightORdark", false);
    }

	private void updatePreferenceLable()
	{
		whatsInPreference.Text = Preferences.Default.Get("favName", "No Saved Location.");
	}
    private void Clear_Clicked(object sender, EventArgs e)
    {
		Preferences.Set("fav", null);
        Preferences.Set("favName", null);
		updatePreferenceLable();      
    }

    protected override void OnAppearing()
    {
        //base.OnAppearing();
        updatePreferenceLable();
    }

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("metericORimperial", metericORimperial.IsToggled);
    }

    private void lightORdark_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("lightORdark", lightORdark.IsToggled);
        Application.Current.Resources.MergedDictionaries.Clear();
        service.lightORdark();
    }
}