using AppShoppingCenter.ViewModels.Stores;

namespace AppShoppingCenter.Views.Stores;

public partial class ListPage : ContentPage
{
	public ListPage(ListPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}