using AppTask.Models;
using AppTask.Navigation;
using AppTask.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppTask.Views;

public partial class StartPage : ContentPage
{
    private readonly ITaskModelRepository _taskModelRepository;
    private readonly INavigationService _navigationService;

    public StartPage(ITaskModelRepository taskModelRepository, INavigationService navigationService)
	{
		InitializeComponent();
        _navigationService = navigationService;
        _taskModelRepository = taskModelRepository;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        LoadData();
    }

    public async void LoadData()
    {
        var tasks = await _taskModelRepository.GetAll();
        CollectionViewTasks.ItemsSource = tasks;
        //LblEmptyText.IsVisible = tasks.Count <= 0;

        //[DICA] - Remove diretamente do componente CollectionView, e reflete na tela caso precisar.
        //((List<TaskModel>)CollectionViewTasks.ItemsSource).Remove();
    }

    private void TextField_TextChanged(object sender, TextChangedEventArgs e)
    {
        //LblSearchStatus.Text = "Testando...";
    }

    private async void OnButtonClickedToAdd(object sender, EventArgs e)
    {
        //Utilizando o modal, não precisa pedir pra ocultar o header do navigation igual foi feito no xaml dessa page (linha 9)
        _navigationService.PushModalAsync<AddEditTaskPage>();
    }

    private void OnBorderClickedToFocusEntry(object sender, TappedEventArgs e)
    {
        Entry_Search.Focus();
    }

    private async void OnImageClickedToDelete(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;
        bool confirm = await DisplayAlert("Confirme a exclusão?", $"Tem certeza que deseja excluir a tarefa: {task.Name} ?", "Sim", "Não");

        if (confirm)
        {
            await _taskModelRepository.Delete(task);
            LoadData();
        }
    }

    private async void DeleteAllItems(object sender, EventArgs e)
    {
        var tasks = ((List<TaskModel>)CollectionViewTasks.ItemsSource);
        await _taskModelRepository.DeleteAll(tasks);

        LoadData();
    }

    private async void OnCheckBoxClickedToComplete(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is TaskModel task)
        {
            task.IsCompleted = e.Value;
            await _taskModelRepository.Update(task);
        }
    }

    private async void OnTapToEdit(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;

        // TODO - Melhorar esse código
        Navigation.PushModalAsync(new AddEditTaskPage(await _taskModelRepository.GetById(task.Id)));
    }
}