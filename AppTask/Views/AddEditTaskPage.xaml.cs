using AppTask.Models;
using UraniumUI.Material.Controls;

namespace AppTask.Views;

public partial class AddEditTaskPage : ContentPage
{
    private TaskModel _task;
	public AddEditTaskPage()
	{
		InitializeComponent();
        _task = new TaskModel();

        BindableLayout.SetItemsSource(BindableLayout_Steps, _task.SubTasks);
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

        if (!string.IsNullOrWhiteSpace(stepName))
        {
            _task.SubTasks.Add(new SubTaskModel
            {
                Name = stepName,
                IsCompleted = false
            });
        }
    }

    // Toda vez ao redimensionar a tela esse método é chamado, e entrega a largura e altura como parâmetros
    protected override void OnSizeAllocated(double width, double height)
    {   
        base.OnSizeAllocated(width, height);

        DatePicker_TaskDate.WidthRequest = width - 30;
    }

    // Da pra usar o Clicked do imageButton, ou o Tapped do Button com GestureRecognizer,
    // Ou Utilizar o conceito de Command, que é mais recomendado (MVVM).
    private async void OnDelete(object sender, EventArgs e)
    {
        if (sender is ImageButton button && button.BindingContext is SubTaskModel subTaskModel)
        {
            // Aqui você tem acesso ao objeto task
            bool confirm = await DisplayAlert("Excluir", $"Deseja excluir {subTaskModel.Name}?", "Sim", "Não");

            if (confirm)
            {
                _task.SubTasks.Remove(subTaskModel);
            }
        }
    }
}