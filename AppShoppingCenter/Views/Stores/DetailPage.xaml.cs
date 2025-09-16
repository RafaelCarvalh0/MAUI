using AppShoppingCenter.ViewModels.Stores;

namespace AppShoppingCenter.Views.Stores;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}