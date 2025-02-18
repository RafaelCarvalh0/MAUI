namespace AppMAUIGallery.Views.Styles;

public partial class StaticDynamicResource : ContentPage
{
    public StaticDynamicResource()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        // Estou acessando diretamente os recursos da minha página atual (ContentPage)
        Resources["TitleColor"] = Color.FromArgb("#00FF00");
        Resources["LabelStyle"] = new Style(typeof(Label))
        {
            Setters =
                {
                    new Setter { Property = Label.PaddingProperty, Value = new Thickness(20) },
                    new Setter { Property = Label.TextColorProperty, Value = Color.FromArgb("#FFFFFF")},
                    new Setter { Property = Label.FontAttributesProperty, Value = FontAttributes.Bold },
                    new Setter { Property = Label.FontSizeProperty, Value = 20},
                    new Setter { Property = Label.BackgroundColorProperty, Value = Color.FromArgb("#0000FF") }
                }
        };

        /*Tambem é possível aplicar estilos de um recurso diretamente a outro recurso dinâmico
         * Resources["Campo"] = Resources["CampoDesativado"];
         * Resources["Campo"] = Resources["CampoAtivado"];
         */
    }
}
