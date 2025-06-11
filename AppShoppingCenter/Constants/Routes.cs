using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.Constants
{
    public static class Routes
    {
        public class RoutePath
        {
            public string Route { get; set; }
            public string RelativePath { get; set; }
        }

        public static RoutePath StoresDetail = new RoutePath
        {
            Route = "stores/detail", // Especificando a rota pai, não gera conflitos de rotas com o mesmo nome 
            RelativePath = "detail" // Caminho relativo de navegação partindo da rota que estou Ex: stores => detail
        };

        public static RoutePath CinemasDetail = new RoutePath
        {
            Route = "cinemas/detail",
            RelativePath = "detail"
        };

        public static RoutePath CinemasDetailDesktop = new RoutePath
        {
            Route = "cinemas/detaildesktop",
            RelativePath = "detaildesktop"
        };

        public static RoutePath RestaurantsDetail = new RoutePath
        {
            Route = "restaurants/detail",
            RelativePath = "detail"
        };

        public static RoutePath TicketsPay = new RoutePath
        {
            Route = "tickets/pay",
            RelativePath = "pay"
        };

        public static RoutePath TicketsList = new RoutePath
        {
            Route = "tickets/list",
            RelativePath = "list"
        };

        public static RoutePath TicketsResult = new RoutePath
        {
            Route = "tickets/result",
            RelativePath = "result"
        };
    }
}
