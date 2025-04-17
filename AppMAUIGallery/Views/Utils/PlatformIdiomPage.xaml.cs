using Microsoft.Maui.Devices;

namespace AppMAUIGallery.Views.Utils;

public partial class PlatformIdiomPage : ContentPage
{
    public PlatformIdiomPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadWarnings();
    }

    private async void LoadWarnings()
    {
        await Task.Delay(1);

        #if WINDOWS
                //Condi��es de compila��o para windows
        #endif

        #if ANDROID
            await DisplayAlert("Condi��es de Compila��o", "Esta � uma mensagem de compila��o executada somente em dispositivos android", "OK");
        #endif



        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            await DisplayAlert("Android", "Esta mensagem � exclusiva do windows", "OK");
        }

        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
        {
            await DisplayAlert("Mobile", "Esta mensagem � exclusiva de dispositivos mobiles", "OK");
        }
    }
}
