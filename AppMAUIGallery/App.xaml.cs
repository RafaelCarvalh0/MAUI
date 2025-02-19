using AppMAUIGallery;

namespace AppMAUIGallery
{
    public partial class App : Application
    {
        public App(MainFlyout flyout)
        {
            InitializeComponent();

            // Reage ao tema claro/escuro no início da aplicação
            Application.Current.RequestedThemeChanged += Current_RequestedThemeChanged;
            MainPage = flyout;
        }

        private void Current_RequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {       
            //if(e.RequestedTheme is AppTheme.Light)
            //    App.Current.MainPage.DisplayAlert("Troca de Tema", "Trocou para o Tema Claro", "Ok");

            //else if(e.RequestedTheme is AppTheme.Dark)
            //    App.Current.MainPage.DisplayAlert("Troca de Tema", "Trocou para o Tema Escuro", "Ok");

        }
    }
}
