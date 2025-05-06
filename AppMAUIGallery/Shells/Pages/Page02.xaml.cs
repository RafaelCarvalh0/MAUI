using System.Web;

namespace AppMAUIGallery.Shells.Pages;

public partial class Page02 : ContentPage
{
	public Page02()
	{
		InitializeComponent();
	}

    private void GoToStep01WithSimpleParameters(object sender, EventArgs e)
    {
		var texto = "Este � um par�metro passado pela tela anterior!";
		var textoCodificado = HttpUtility.UrlEncode(texto);
		Shell.Current.GoToAsync($"page02step01withparameters?msg={textoCodificado}");
    }
}