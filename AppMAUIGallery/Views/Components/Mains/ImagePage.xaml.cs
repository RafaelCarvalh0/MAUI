namespace AppMAUIGallery.Views.Components.Mains;

public partial class ImagePage : ContentPage
{
	public ImagePage()
	{
		InitializeComponent();
        /* 
          Imagem01 can have up to four values
          ImageSource.FromFile
		  ImageSource.FromResource
          ImageSource.FromStream
          ImageSource.FromUri
        */
        Imagem01.Source = ImageSource.FromUri(new Uri("https://cpv.ifsp.edu.br/images/phocagallery/galeria2/thumbs/phoca_thumb_l_image03_grd.png"));
	}
}