using AppShoppingCenter.Constants;

namespace AppShoppingCenter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(Routes.StoresDetail, typeof(Views.Stores.DetailPage));
        }
    }
}
