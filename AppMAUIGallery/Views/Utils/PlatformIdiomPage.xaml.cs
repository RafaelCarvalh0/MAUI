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
                //Condições de compilação para windows
        #endif

        #if ANDROID
            await DisplayAlert("Condições de Compilação", "Esta é uma mensagem de compilação executada somente em dispositivos android", "OK");
        #endif



        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            await DisplayAlert("Android", "Esta mensagem é exclusiva do windows", "OK");
        }

        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
        {
            await DisplayAlert("Mobile", "Esta mensagem é exclusiva de dispositivos mobiles", "OK");
        }
    }
}
