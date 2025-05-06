namespace AppMAUIGallery.Shells.Pages;

public partial class Page01Step02 : ContentPage
{
	public Page01Step02()
	{
		InitializeComponent();
	}

    private void GoBack(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("../page01step01");
    }

    private void GoToRegisterStep02(object sender, EventArgs e)
    {
        //Rota atual: page01/page01step02

        //Rota Relativa: cadastro/passo2
        //Shell.Current.GoToAsync("../../cadastro/passo2");

        //Rota Absoluta (//)
        Shell.Current.GoToAsync("//cadastro/passo2");
    }

    private void GoToRegisterStep01(object sender, EventArgs e)
    {
        //Rota Absoluta (//)
        Shell.Current.GoToAsync("///passo1");
    }
}