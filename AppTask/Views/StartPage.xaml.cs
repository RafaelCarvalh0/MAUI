namespace AppTask.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    private void TextField_TextChanged(object sender, TextChangedEventArgs e)
    {
        //LblSearchStatus.Text = "Testando...";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //Utilizando o modal, não precisa pedir pra ocultar o header do navigation igual foi feito no xaml dessa page (linha 9)
        Navigation.PushModalAsync(new AddEditTaskPage());
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Entry_Search.Focus();
    }
}