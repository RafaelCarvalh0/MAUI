using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace AppMAUIGallery.Views.CommunityMaui;

public partial class AlertsPage : ContentPage
{
	public AlertsPage()
	{
		InitializeComponent();
	}

    private void OnButtonClicked_ShowSnackbar(object sender, EventArgs e)
    {
        var btn = sender as Button;

        // Configuração Visual
        var options = new SnackbarOptions
        {
            BackgroundColor = Colors.White,
            TextColor = Colors.Red,   
            ActionButtonTextColor = Colors.Red,
            CornerRadius = 8
        };

        // Criação do Objeto
        var snackBar = Snackbar.Make(
            "Ocorreu um erro inesperado!",
            // Ação personalizada ao clicar no botão
            //action: () =>
            //{
            //    // Ação ao clicar no botão
            //    DisplayAlert("SnackBar", "SnackBar Fechado", "OK");
            //}, 
            null,
            "OK",
            duration: TimeSpan.FromSeconds(3),
            options/*,
            btn*/); // Ancora o snack perto do botão de origem

        // Apresentação da Snack
        snackBar.Show();
    }

    private void OnButtonClicked_ShowToast(object sender, EventArgs e)
    {
        var btn = ((Button)sender);

        var toast = Toast.Make("Ocorreu um erro inesperado!", ToastDuration.Long, 14);

        toast.Show();
    }
}