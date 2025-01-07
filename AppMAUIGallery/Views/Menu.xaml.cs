using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{
	private readonly IGroupComponentRepository _groupComponentRepository;

    // Construtor parametrizável para receber uma instância do meu objeto do contâiner DI.
    public Menu(IGroupComponentRepository groupComponentRepository)
    {
        InitializeComponent();
        _groupComponentRepository = groupComponentRepository;

        LoadMenu();
    }

    // A view do xaml não sabe enviar parâmetros para o code behind, por isso o construtor deve ser vazio
    public Menu() : this(MauiProgram.Services.GetRequiredService<IGroupComponentRepository>())
    {
        
    }

    private void LoadMenu()
    {
        MenuCollection.ItemsSource = _groupComponentRepository.GetGroupComponents();
    }

    private void OnTapComponent(object sender, TappedEventArgs e)
    {
        try
        {
            //[ OLD ]
            //var label = (Label)sender;
            //var tap = (TapGestureRecognizer)label.GestureRecognizers[0];
            //(Type)tap.CommandParameter;
            var pageType = (Type)e.Parameter; 

            //Navegação sem utilizar páginas injetadas no container DI.
            //((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(pageType));
            //((FlyoutPage)App.Current.MainPage).IsPresented = false;

            //Navegação utilizando páginas injetadas no container DI.
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