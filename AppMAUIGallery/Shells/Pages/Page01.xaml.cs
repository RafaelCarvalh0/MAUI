namespace AppMAUIGallery.Shells.Pages;

public partial class Page01 : ContentPage
{
	public Page01()
	{
		InitializeComponent();
	}

    private void GoToStep01(object sender, EventArgs e)
    {
		// Rota Relativa: /page01/page01step01
		// GoToAsync é o mesmo que PushAsync
		Shell.Current.GoToAsync("page01step01");
    }
}