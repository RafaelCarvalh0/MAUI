using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{
	private readonly ICategoryRepository _categoryRepository;

    public Menu()
    {
        InitializeComponent();
        _categoryRepository = MauiProgram.Services.GetRequiredService<ICategoryRepository>();

        GetCategories();
    }

 //   public Menu(ICategoryRepository categoryRepository)
	//{
 //       InitializeComponent();
 //       _categoryRepository = categoryRepository;

	//	GetCategories();
	//}

    private async void GetCategories()
    {
		try
		{
            var categories = await _categoryRepository.GetCategories();

            foreach (var category in categories)
            {
                var lblCategory = new Label();
                lblCategory.Text = category.Name;
                lblCategory.FontFamily = "OpenSansSemibold";

                MenuContainer.Children.Add(lblCategory);

                foreach(var component in category.Components)
                {
                    var tap = new TapGestureRecognizer();
                    tap.CommandParameter = component.Page;
                    tap.Tapped += OnTapComponent;

                    var lblComponentTitle = new Label();    
                    lblComponentTitle.Text = component.Title;
                    lblComponentTitle.FontFamily = "OpenSansSemibold";
                    lblComponentTitle.Margin = new Thickness(20, 10, 0, 0);
                    lblComponentTitle.GestureRecognizers.Add(tap);

                    var lblComponentDescription = new Label();  
                    lblComponentDescription.Text = component.Description;
                    lblComponentDescription.Margin = new Thickness(20, 0, 0, 0);
                    lblComponentDescription.GestureRecognizers.Add(tap);

                    MenuContainer.Children.Add(lblComponentTitle);  
                    MenuContainer.Children.Add(lblComponentDescription);  
                }
            }
        }
		catch (Exception ex)
		{
			throw ex;
		}
    }

    private void OnTapComponent(object sender, EventArgs e)
    {
        var label = (Label)sender;
        var tap = (TapGestureRecognizer)label.GestureRecognizers[0];
        var page = (Type)tap.CommandParameter;

        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(page));
        //((FlyoutPage)App.Current.MainPage).Title = page.Name;
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }

    private void OnTapHome(object sender, TappedEventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new AppMAUIGallery.Views.MainPage());
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }
}