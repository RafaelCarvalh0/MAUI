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
        if(firstTime is false)
        {
            btn_playpause.TranslateTo(- player.Width / 2, player.Width / 2, 500);
            firstTime = true;
        }

        if (player.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
        {
            player.Pause();
            btn_playpause.Source = ImageSource.FromFile("play.png");
        }

        else
        {
            player.Play();
            btn_playpause.Source = ImageSource.FromFile("pause.png");
        }
    }
}