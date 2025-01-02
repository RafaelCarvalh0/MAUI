using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{
	private readonly ICategoryRepository _categoryRepository;

    // Construtor parametrizável para receber uma instância do meu objeto do contâiner DI.
    public Menu(ICategoryRepository categoryRepository)
    {
        InitializeComponent();
        _categoryRepository = categoryRepository;

        GetCategories();
    }

    // A view do xaml não sabe enviar parâmetros para o code behind, por isso o construtor deve ser vazio
    public Menu() : this(MauiProgram.Services.GetRequiredService<ICategoryRepository>())
    {
        
    }

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
        try
        {
            var label = (Label)sender;
            var tap = (TapGestureRecognizer)label.GestureRecognizers[0];
            var pageType = (Type)tap.CommandParameter;

            if (MauiProgram.Services.GetService(pageType) is Page page)
            {
                var navigationPage = new NavigationPage(page);

                ((FlyoutPage)App.Current.MainPage).Detail = navigationPage;
                ((FlyoutPage)App.Current.MainPage).IsPresented = false;
            }
            else
            {
                throw new InvalidOperationException($"Page of type {pageType.Name} not registered in DI.");
            }
        }
        catch (Exception ex)
        {
            // Trate erros ou registre logs
            Console.WriteLine($"Navigation error: {ex.Message}");
        }
    }
    private void OnTapHome(object sender, TappedEventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new AppMAUIGallery.Views.MainPage());
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }
}