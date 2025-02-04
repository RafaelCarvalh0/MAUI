using Android.Graphics.Drawables;
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
            EntryNoBorder();
            DatePickerNoBorder();
            EditorNoBorder();
        }


        private static void EntryNoBorder()
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
                handler.PlatformView.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS || MACCATALYST
                                        //Revovendo no iOS || MAC CATALYST
                                        handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                         //Windows - it's not working a hundred percent  
                                        handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif

            });
        }

        private static void DatePickerNoBorder()
        {
            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
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
                //handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS || MACCATALYST
                                        //Revovendo no iOS || MAC CATALYST
                                        handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                         //Windows - it's not working a hundred percent  
                                        handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif

            });
        }

        private static void EditorNoBorder()
        {
            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            {
#if ANDROID
                // Removendo a borda e o fundo do Editor no Android
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
                handler.PlatformView.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS || MACCATALYST
        // Removendo a borda do Editor no iOS e MacCatalyst
        handler.PlatformView.Layer.BorderWidth = 0;
        handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
#elif WINDOWS
        // Tentativa de remover a borda no Windows (não funciona 100%)
        handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif
            });
        }
    }
}
