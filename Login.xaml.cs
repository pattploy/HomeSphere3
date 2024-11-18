namespace HomeSphere2;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
        this.BackgroundImageSource = "homee.png";
    }
    private void OnLoginClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Home());
    }
}
