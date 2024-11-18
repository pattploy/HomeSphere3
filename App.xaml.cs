namespace HomeSphere2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //MainPage = new Repair();
            //MainPage = new Parcel();
            MainPage = new NavigationPage(new Login());
        }
    }
}
