using AppMAUIGallery.Models;
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
		var texto = "Este é um parâmetro passado pela tela anterior!";
		var textoCodificado = HttpUtility.UrlEncode(texto);
		Shell.Current.GoToAsync($"page02step01withparameters?msg={textoCodificado}");
    }

    private void GoToStep01WithComplexParameters(object sender, EventArgs e)
    {
		var person = new Person() { Id = 1, Name = "Rafael Henrique de Carvalho", Email = "rafaelhenriquecarvalho@outlook.com" };

		var parameters = new Dictionary<string, object>
		{
            { "msg", "Este é um parâmetro passado de forma complexa!" },
            { "person", person }
        };

		Shell.Current.GoToAsync($"page02step01withparameters", parameters);
    }
}