namespace AppNavigationPage;

public partial class Page2 : ContentPage
{
	public Page2()
	{
		InitializeComponent();
	}

    private void OnProceed(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Page3()); // Prossegue para uma nóva página
    }

    private void OnReturn(object sender, EventArgs e)
    {
        Navigation.PopAsync(); //Retorna para a página anterior

        //Navigation.NavigationStack.Count(); //Uma lista de pilha de páginas na memória
        //Navigation.ModalStack //Modal não tem barra de título, similar a um alert no react.
        //Navigation.PopModalAsync(); //Normalmente chamado com o botão de fechar do modal.
        //Navigation.PopToRootAsync(); //Volta para a primeira pilha (página 1)
        //Navigation.RemovePage(Navigation.NavigationStack[1]); //Remove uma página específica da pilha, no caso estou removendo a página 2 da memória.
        //Navigation.InsertPageBefore(new Page3(), Navigation.NavigationStack[1]); // Insere uma página em uma posição específica da pilha.
    }
}