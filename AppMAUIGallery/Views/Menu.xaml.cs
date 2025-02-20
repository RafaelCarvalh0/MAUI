using AppMAUIGallery.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IGroupComponentRepository _groupComponentRepository;

    // Construtor parametrizável para receber uma instância do meu objeto do contâiner DI.
    public Menu(IGroupComponentRepository groupComponentRepository, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _groupComponentRepository = groupComponentRepository;
        _serviceProvider = serviceProvider;

        LoadMenu();
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
            if (_serviceProvider.GetService(pageType) is Page page)
            {
                var navigationPage = new NavigationPage(page);

                ((FlyoutPage)App.Current.MainPage).Detail = navigationPage;
                ((FlyoutPage)App.Current.MainPage).IsPresented = false;
            }
        }
        catch (Exception ex)
        {
            // Trate erros ou registre logs
            DisplayAlert("Erro", ex.Message, "OK");
            Console.WriteLine($"Navigation error: {ex.Message}");
        }
    }
    private void OnTapHome(object sender, TappedEventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(_serviceProvider.GetRequiredService<MainPage>());
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }
}