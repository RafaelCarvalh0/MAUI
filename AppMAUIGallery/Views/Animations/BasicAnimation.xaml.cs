namespace AppMAUIGallery.Views.Animations;

public partial class BasicAnimation : ContentPage
{
    public BasicAnimation()
    {
        InitializeComponent();
    }

    private async void Diminuir(object sender, EventArgs e)
    {
        // Todo Scale tem um padrão de 1
        // Aqui estou pedindo pra diminuir o tamanho na metade.
        await Image.ScaleTo(0.5, 2000);
    }

    private async void Aumentar(object sender, EventArgs e)
    {
        // Aumenta o dobro do tamanho do Robô
        await Image.ScaleTo(2, 2000);
    }

    private void Normal(object sender, EventArgs e)
    {
        ClearState();
    }

    private async void Mover(object sender, EventArgs e)
    {
        await Image.TranslateTo(100, 100, 1000);
    }

    private async void Rotacao(object sender, EventArgs e)
    {
        await Image.RotateTo(720, 2000);
        await Image.RotateXTo(360, 1000);
        await Image.RotateYTo(1440, 4000);

        // Rel (Relativo) sempre vai acrescentar um novo valor de rotação em uma rotação já existente.
        // Toda vez que o método Rotacao for clicado irá incrementar.
        //await Image.RelRotateTo(90, 1000);

        ClearState();
    }

    private async void Transparencia(object sender, EventArgs e)
    {
        await Image.FadeTo(0.3, 1000);
    }
    private async void Sequencial(object sender, EventArgs e)
    {
        await Image.TranslateTo(130, 0, 300);
        await Image.TranslateTo(-130, 0, 600);
        await Image.TranslateTo(0, 0, 300);
    }

    private async void Paralelo(object sender, EventArgs e)
    {
        // Cria uma tarefa que aguarda todas as tasks serem concluídas.
        await Task.WhenAll(
            Image.TranslateTo(100, 0, 1000),
            Image.RotateTo(360, 1000),
            Image.FadeTo(0.6, 1000)
            );
    }

    private void Cancelamento(object sender, EventArgs e)
    {
        // Cancela as animações que estão sendo executadas.
        Image.CancelAnimations();
    }

    private void ClearState()
    {
        //Image.ScaleTo(1, 2000);
        Image.Scale = 1;
        Image.TranslationX = 0;
        Image.TranslationY = 0;
        Image.Opacity = 1;
        Image.RotationX = 0;
        Image.RotationY = 0;
        Image.RotateTo(0, 1);
    }
}