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

    //private void EditorField_Focused(object sender, FocusEventArgs e)
    //{
    //    var textField = (EditorField)sender;
    //    textField.MinimumHeightRequest = 200;
    //}
}