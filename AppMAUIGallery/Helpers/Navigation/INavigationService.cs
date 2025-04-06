using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Navigation
{
    public interface INavigationService
    {
        Task PushModalAsync<TPage>() where TPage : Page;
    }

    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task PushModalAsync<TPage>() where TPage : Page
        {
            var page = _serviceProvider.GetRequiredService<TPage>();
            return Application.Current.MainPage.Navigation.PushModalAsync(page);
        }
    }
}
