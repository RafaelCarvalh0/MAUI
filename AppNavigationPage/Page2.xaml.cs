namespace AppNavigationPage;

public partial class Page2 : ContentPage
{
	public Page2()
	{
		InitializeComponent();
	}

    private void OnProceed(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Page3()); // Prossegue para uma n�va p�gina
    }

    private void OnReturn(object sender, EventArgs e)
    {
        Navigation.PopAsync(); //Retorna para a p�gina anterior

        //Navigation.NavigationStack.Count(); //Uma lista de pilha de p�ginas na mem�ria
        //Navigation.ModalStack //Modal n�o tem barra de t�tulo, similar a um alert no react.
        //Navigation.PopModalAsync(); //Normalmente chamado com o bot�o de fechar do modal.
        //Navigation.PopToRootAsync(); //Volta para a primeira pilha (p�gina 1)
        //Navigation.RemovePage(Navigation.NavigationStack[1]); //Remove uma p�gina espec�fica da pilha, no caso estou removendo a p�gina 2 da mem�ria.
        //Navigation.InsertPageBefore(new Page3(), Navigation.NavigationStack[1]); // Insere uma p�gina em uma posi��o espec�fica da pilha.
    }
}