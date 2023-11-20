namespace Dasiy_Weather.views;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
		updatePreferenceLable();
	}

	private void updatePreferenceLable()
	{
		whatsInPreference.Text = Preferences.Default.Get("favName", "None Saved Location.");
	}
    private void Clear_Clicked(object sender, EventArgs e)
    {
		Preferences.Clear();
		updatePreferenceLable();
    }
}