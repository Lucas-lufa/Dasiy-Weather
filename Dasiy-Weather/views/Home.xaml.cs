namespace Dasiy_Weather.views;

public partial class Home : ContentPage
{
    APIService service;
    public Home()
	{
		InitializeComponent();
        service = ((App)Application.Current).Service;
    }


    protected override async void OnAppearing()
    {
        //base.OnAppearing();
        output.Text = await service.displayFav();
    }

}