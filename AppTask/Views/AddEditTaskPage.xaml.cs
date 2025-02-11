using AppTask.Models;
using AppTask.Repositories;
using System.Text;
using UraniumUI.Material.Controls;

namespace AppTask.Views;

public partial class AddEditTaskPage : ContentPage
{
    private readonly ITaskModelRepository _taskModelRepository;
    private TaskModel _task;
	public AddEditTaskPage(ITaskModelRepository taskModelRepository)
	{
		InitializeComponent();
        _task = new TaskModel();
        _taskModelRepository = taskModelRepository;

        BindableLayout.SetItemsSource(BindableLayout_Steps, _task.SubTasks);
	}

    // Construtor para EDIT
    public AddEditTaskPage(TaskModel task)
    {
        InitializeComponent();
        _task = task;
        FillFields();

        BindableLayout.SetItemsSource(BindableLayout_Steps, _task.SubTasks);
    }

    private void FillFields()
    {
        Entry_TaskName.Text = _task.Name;
        Editor_TaskDescription.Text = _task.Description;
        DatePicker_TaskDate.Date = _task.PrevisionDate;
    }

    private void CloseModal(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private void SaveData(object sender, EventArgs e)
    {
        // Obter os dados
        GetDataFromForm();

        // Válidar os dados
        bool valid = ValidateData();

        // Salvar os dados 
        if (valid)
        {
            SaveInDatabase();

            // Fechar a tela
            Navigation.PopModalAsync();

            // Solicitar a atualização da listagem da tela anterior
            UpdateListInStartPage();

            //Navigation.PopModalAsync();
        }
    }

    private void GetDataFromForm()
    {
        _task.Name = Entry_TaskName.Text;
        _task.Description = Editor_TaskDescription.Text;
        _task.PrevisionDate = DatePicker_TaskDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999);

        _task.Created = DateTime.Now;
        _task.IsCompleted = false;
    }

    private bool ValidateData()
    {
        Label_TaskName_Required.IsVisible = false;
        Label_TaskDescription_Required.IsVisible = false;
        //StringBuilder sb = new StringBuilder();

        bool validResult = true;
        if (string.IsNullOrWhiteSpace(_task.Name))
        {
            //sb.AppendLine("Nome da tarefa é obrigatório.");
            //Label_TaskName_Required.Text = "Nome da tarefa é obrigatório.";
            Label_TaskName_Required.IsVisible = true;
            validResult = false;
        }
        if (string.IsNullOrWhiteSpace(_task.Description))
        {
            //sb.AppendLine("Descrição da tarefa é obrigatório.");
            //Label_TaskDescription_Required.Text = "Descrição da tarefa é obrigatório.";
            Label_TaskDescription_Required.IsVisible = true;
            validResult = false;
        }
        //if (_task.PrevisionDate < DateTime.Now)
        //{
        //    sb.AppendLine("Data de previsão deve ser maior que a data atual.");
        //    validResult = false;
        //}



        return validResult;
    }

    private async void SaveInDatabase()
    {
        if (_task.Id is 0)
            await _taskModelRepository.Add(_task);

        else
            await _taskModelRepository.Update(_task);
    }

    private void UpdateListInStartPage()
    {
        //Busco a página Atual em App
        var navPage = (NavigationPage)App.Current.MainPage;

        // Busco a startPage, que é uma page dentro do navigationPage
        var StartPage = (StartPage)navPage.CurrentPage;

        // chamo o método LoadData() da startPage
        StartPage.LoadData();
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