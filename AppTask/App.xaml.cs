using AppTask.Views;
using Microsoft.Maui.Platform;
using UraniumUI.Material.Controls;

namespace AppTask
{
    public partial class App : Application
    {
        public App()
        {
            CustomHandler();
            InitializeComponent();

            // Setando como NavigationPage, poi queremos que há navegação entre as páginas.
            MainPage = new NavigationPage(new StartPage());
        }

        private void CustomHandler()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            {

                //Ex: Converte a cor "AliceBlue" para a respectiva plataforma
                //Colors.AliceBlue.ToPlatform();

                /* 
                 * Cada propriedade em PlatformView é uma propriedade nativa
                 * Portanto checar os icones de exclamação em cada propriedade
                */

#if ANDROID
                //Removendo borda de todos os campos Entry no android
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
#elif IOS || MACCATALYST
                                        //Revovendo no iOS || MAC CATALYST
                                        handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                         //Windows - it's not working a hundred percent  
                                        handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif

            });
         
        }
    }
}
