using AppShoppingCenter.Constants;

namespace AppShoppingCenter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(Routes.StoresDetail, typeof(Views.Stores.DetailPage));
            Routing.RegisterRoute(Routes.RestaurantsDetail, typeof(Views.Restaurants.DetailPage));
            Routing.RegisterRoute(Routes.CinemasDetail, typeof(Views.Cinemas.DetailPage));
            Routing.RegisterRoute(Routes.CinemasDetailDesktop, typeof(Views.Cinemas.DetailDesktopPage));

            Routing.RegisterRoute(Routes.TicketsPay, typeof(Views.Tickets.PayPage));
            Routing.RegisterRoute(Routes.TicketsList, typeof(Views.Tickets.ListPage));
            Routing.RegisterRoute(Routes.TicketsResult, typeof(Views.Tickets.ResultPage));
        }
    }
}
