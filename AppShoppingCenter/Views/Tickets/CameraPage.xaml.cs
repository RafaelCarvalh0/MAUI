using AppShoppingCenter.Constants;
using AppShoppingCenter.Services;

namespace AppShoppingCenter.Views.Tickets;

public partial class CameraPage : ContentPage
{
    private readonly ITicketService _ticketService;
	public CameraPage(ITicketService ticketService)
	{
		InitializeComponent();
        _ticketService = ticketService;
    }

    public CameraPage() : this(App.Current.Handler.MauiContext.Services.GetRequiredService<ITicketService>() ?? throw new InvalidOperationException("Servi�o n�o resolvido")) 
    { 

    }

    private async void OnBarcodeDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
		var ticketNumber = e.Results[0].Value;

        //TODO Verificar se o c�digo existe no Banco/API/Mock.
        var ticket = await _ticketService.GetTicket(ticketNumber);

        //TODO CASE Mensagem de alerta.
        if (ticket is null)
        {
            await DisplayAlert("Ticket n�o encontrado!", $"N�o localizamos um ticket com o n�mero {ticketNumber}.", "OK");
            return;
        }

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Shell.Current.GoToAsync($"../{Routes.TicketsPay.RelativePath}", true, new Dictionary<string, object>()
            {
                { "ticket", ticket }
            });
        });   
    }
}