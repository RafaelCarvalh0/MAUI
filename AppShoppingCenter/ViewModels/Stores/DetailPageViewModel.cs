using AppShoppingCenter.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Stores
{
    [QueryProperty(nameof(Establishment), "establishment")]
    public partial class DetailPageViewModel : ObservableObject//, IQueryAttributable
    {
        [ObservableProperty]
        private Establishment establishment;

        //public void ApplyQueryAttributes(IDictionary<string, object> query)
        //{
        //    if (query.TryGetValue("establishment", out var modelParam))
        //    {
        //        Establishment = JsonConvert.DeserializeObject<Establishment>(JsonConvert.SerializeObject(modelParam));
        //    }
        //}

        [RelayCommand]
        private async Task OnTapToBack()
        {   
            await Shell.Current.GoToAsync("..");
        }
    }
}
