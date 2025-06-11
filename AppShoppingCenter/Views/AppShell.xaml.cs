using AppShoppingCenter.Constants;

namespace AppShoppingCenter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(Routes.StoresDetail.Route, typeof(Views.Stores.DetailPage));
            Routing.RegisterRoute(Routes.RestaurantsDetail.Route, typeof(Views.Restaurants.DetailPage));
            Routing.RegisterRoute(Routes.CinemasDetail.Route, typeof(Views.Cinemas.DetailPage));
            Routing.RegisterRoute(Routes.CinemasDetailDesktop.Route, typeof(Views.Cinemas.DetailDesktopPage));

            Routing.RegisterRoute(Routes.TicketsPay.Route, typeof(Views.Tickets.PayPage));
            Routing.RegisterRoute(Routes.TicketsList.Route, typeof(Views.Tickets.ListPage));
            Routing.RegisterRoute(Routes.TicketsResult.Route, typeof(Views.Tickets.ResultPage));
        }
    }
}
