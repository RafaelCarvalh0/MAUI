﻿
using AppMVVMCommunityToolkit.Libraries.Messages;
using AppMVVMCommunityToolkit.Models;
using AppMVVMCommunityToolkit.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMVVMCommunityToolkit.ViewModels
{
    public partial class StartPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string message;

        [ObservableProperty]
        private Person person;
        public ObservableCollection<Person> People { get; set; }
        public StartPageViewModel()
        {
            Person = new Person();
            People = new ObservableCollection<Person>();

            // [SUBSCRIBE] Registra a página inicial como um inscrito
            // Define que irá receber as Mensagens (Notificações) do tipo <TextMessage>
            WeakReferenceMessenger.Default.Register<TextMessage>(this, (obj, msg) =>
            {
                //TODO - Lógica
                Message = msg.Value;
            });

            WeakReferenceMessenger.Default.Register<PersonMessage>(this, (obj, msg) =>
            {
                //TODO - Lógica
                People.Add(msg.Value);
            });
        }

        [RelayCommand]
        private void Save()
        {
            People.Add(Person);
            Person = new Person();
        }

        [RelayCommand]
        private void GoToPubSubPage()
        {
            NavigationPage navPag = (NavigationPage)App.Current.MainPage;
            navPag.PushAsync(new PubSubPage());
        }
    }
}
