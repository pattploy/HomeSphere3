using HomeSphere2.Services;
using HomeSphere2.ViewModels;

namespace HomeSphere2;

public partial class Repair : ContentPage
{
	public Repair()
	{
		InitializeComponent();
        this.BackgroundImageSource = "pupu.png";
        var firestoreService = new FirestoreService();
        BindingContext = new RepairViewModel(firestoreService);
    }
}