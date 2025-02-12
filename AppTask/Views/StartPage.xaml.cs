using AppTask.Models;
using AppTask.Navigation;
using AppTask.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace AppTask.Views;

public partial class StartPage : ContentPage
{
    private readonly ITaskModelRepository _taskModelRepository;
    private readonly INavigationService _navigationService;
    private IList<TaskModel> _tasks;

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
        _tasks = await _taskModelRepository.GetAll();
        CollectionViewTasks.ItemsSource = new ObservableCollection<TaskModel>(_tasks); 
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

    private void OnTextChanged_FilterList(object sender, TextChangedEventArgs e)
    {
        var searchText = e.NewTextValue.ToLower().Trim();
        Clear();
        Search(searchText);
    }

    private void Clear()
    {
        var limit = (CollectionViewTasks.ItemsSource as ObservableCollection<TaskModel>).Count;

        for (int i = 0; i < limit; i++)
        {
            (CollectionViewTasks.ItemsSource as ObservableCollection<TaskModel>).RemoveAt(0);
        }
    }

    private void Search(string searchText)
    {
        //_tasks.Where(a => )
        var filtredList = _tasks.Where(component => Regex.IsMatch(component.Name.ToLower().Trim(), @"^" + string.Join(@"\s+", searchText.Split(' ')))).ToList();

        foreach (var component in filtredList)
        {
            (CollectionViewTasks.ItemsSource as ObservableCollection<TaskModel>).Add(component);
        }

        if ((CollectionViewTasks.ItemsSource as ObservableCollection<TaskModel>).Count == 0)
            CollectionViewTasks.EmptyView = "Não foram encontrados dados na busca";
        else
            CollectionViewTasks.EmptyView = string.Empty; // Limpa a mensagem de erro, caso haja resultados
    }
}