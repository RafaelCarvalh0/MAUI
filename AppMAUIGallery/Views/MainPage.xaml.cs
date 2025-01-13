using AppMAUIGallery.Libraries.Fix;
using AppMAUIGallery.Models;
using AppMAUIGallery.Repositories;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace AppMAUIGallery.Views;

public partial class MainPage : ContentPage
{
    private readonly IGroupComponentRepository _groupComponentRepository;
    private List<Component> _fullList;

    public MainPage(IGroupComponentRepository groupComponentRepository)
    {
        InitializeComponent();
        _groupComponentRepository = groupComponentRepository;

        GetComponents();
    }

    // A view do xaml não sabe enviar parâmetros para o code behind, por isso o construtor vazio deve ser criado
    public MainPage() : this(MauiProgram.Services.GetRequiredService<IGroupComponentRepository>())
    {

    }

    private void GetComponents()
    {
        _fullList = _groupComponentRepository.GetComponents();
        ComponentCollection.ItemsSource = new ObservableCollection<Component>(_fullList);
    }

    private void OnTapComponent(object sender, TappedEventArgs e)
    {
        KeyboardFix.HideKeyboard();
        var pageType = (Type)e.Parameter;

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

    private void TextField_TextChanged(object sender, TextChangedEventArgs e)
    {
        var searchText = e.NewTextValue?.ToLower().Trim() ?? string.Empty;

        Clear();
        Search(searchText);
    }

    private void Clear()
    {
        var limit = (ComponentCollection.ItemsSource as ObservableCollection<Component>).Count;

        for (int i = 0; i < limit; i++)
        {
            (ComponentCollection.ItemsSource as ObservableCollection<Component>).RemoveAt(0);
        }
    }

    private void Search(string searchText)
    {
        var filtredList = _fullList.Where(component => Regex.IsMatch(component.Title.ToLower().Trim(), @"^" + string.Join(@"\s+", searchText.Split(' ')))).ToList();

        foreach (var component in filtredList)
        {
            (ComponentCollection.ItemsSource as ObservableCollection<Component>).Add(component);
        }

        if ((ComponentCollection.ItemsSource as ObservableCollection<Component>).Count == 0)
            LblSearchStatus.Text = "Não foram encontrados dados na busca";
        else
            LblSearchStatus.Text = string.Empty; // Limpa a mensagem de erro, caso haja resultados
    }
}