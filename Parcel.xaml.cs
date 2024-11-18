using HomeSphere2.Services;
using HomeSphere2.ViewModels;

namespace HomeSphere2;

public partial class Parcel : ContentPage
{
	public Parcel()
	{
		InitializeComponent();
        this.BackgroundImageSource = "pupu.png";
        var firestoreService = new FirestoreService();
        BindingContext = new UserViewModel(firestoreService);
    }
}