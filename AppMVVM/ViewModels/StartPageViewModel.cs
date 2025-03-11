using AppMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMVVM.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
    {
        public StartPageViewModel()
        {
            // 2º passo
            SaveCommand = new Command(Save);
            Person = new Person();
            People = new ObservableCollection<Person>();
        }

        // 3º passo
        private void Save()
        {
            // Só adiciona na lista se a instância não for nula e for válida
            if (Person is not null && IsValid())
            {
                People.Add(Person);
                Person = new Person();
            }
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_person.Name) && !string.IsNullOrWhiteSpace(_person.Email);
        }

        #region To Form

        private Person _person;

        public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                OnPropertyChanged(nameof(Person));
            }
        }

        // 1º passo
        public ICommand SaveCommand { get; set; }
        #endregion

        #region ObservableCollection
        // Já implementa o INotifyPropertyChanged e o INotifyCollectionChanged
        // Ou seja, notifica quando a instância é alterada, ou quando items são adicionados a coleção
        public ObservableCollection<Person> People { get; set; }
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged is not null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
