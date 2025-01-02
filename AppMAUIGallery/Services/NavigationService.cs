using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Services
{
    public class NavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public T ResolvePage<T>() where T : Page
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public async Task NavigateToPageAsync<T>() where T : Page
        {
            var page = ResolvePage<T>();
            await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(page);
        }
    }
}
