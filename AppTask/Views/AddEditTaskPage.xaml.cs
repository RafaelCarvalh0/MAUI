using UraniumUI.Material.Controls;

namespace AppTask.Views;

public partial class AddEditTaskPage : ContentPage
{
	public AddEditTaskPage()
	{
		InitializeComponent();
	}

    private void CloseModal(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private void SaveData(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void AddStep(object sender, EventArgs e)
    {
        //Prompt de input de dados
        var stepName = await DisplayPromptAsync("Etapa(subtarefa)", "Digite o nome da etapa(subtarefa):", "Adicionar", "Cancelar");
    }

    // Toda vez ao redimensionar a tela esse método é chamado, e entrega a largura e altura como parâmetros
    protected override void OnSizeAllocated(double width, double height)
    {   
        base.OnSizeAllocated(width, height);

        DatePicker_TaskDate.WidthRequest = width - 30;
    }
}