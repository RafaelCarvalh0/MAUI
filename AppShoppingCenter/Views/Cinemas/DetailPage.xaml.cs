namespace AppShoppingCenter.Views.Cinemas;

public partial class DetailPage : ContentPage
{
    bool firstTime = false;
    public DetailPage()
    {
        InitializeComponent();
    }

    private void PlayPause(object sender, TappedEventArgs e)
    {
        var btn = (Image)sender;

        if(firstTime is false)
        {


            firstTime = true;
        }

        if (player.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
        {
            // Volta à posição original e opacidade
            btn_playpause.TranslateTo(0, 0, 300);
            MovieText.TranslateTo(0, 0);
            btn_playpause.Opacity = 0.7;

            player.Pause();
            btn_playpause.Source = ImageSource.FromFile("play.png");
        }

        else
        {
            var mediaWidthHalf = player.Width / 2 - btn.Width + 10;
            var mediaHeightHalf = player.Height / 2 - btn.Height + 25;

            btn_playpause.TranslateTo(-mediaWidthHalf, mediaHeightHalf, 300);
            MovieText.TranslateTo(0, 40);
            btn_playpause.Opacity = 0.3;

            player.Play();
            btn_playpause.Source = ImageSource.FromFile("pause.png");
        }
    }
}