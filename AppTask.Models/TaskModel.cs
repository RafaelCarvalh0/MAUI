using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AppTask.Models
{
    public class BaseNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class TaskModel : BaseNotify
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PrevisionDate { get; set; }

        private bool _isCompleted;

        public bool IsCompleted 
        {
            get { return _isCompleted; } //( Ao buscar ) No get de "IsCompleted" é retornadoo valor de "_IsCompleted"
            set
            {
                //Setter Chamar a Notificação
                _isCompleted = value; // ( Ao setar ) No set de "IsCompleted" o valor é passado para "_IsCompleted"
                OnPropertyChanged(nameof(IsCompleted)); // Chama o método que avisa sobre a propriedade alterada. 
            }
        }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        //ObservableCollection observa se há mudanças na collection, + ou - items por ex:
        // Deve ser implementado para notificar o componente visual (Bindable layout) corretamente.
        public ObservableCollection<SubTaskModel> SubTasks { get; set; } = new ObservableCollection<SubTaskModel>();
    }

    public class SubTaskModel : BaseNotify
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private bool _isCompleted;

        public bool IsCompleted
        {
            get { return _isCompleted; } //( Ao buscar ) No get de "IsCompleted" é retornadoo valor de "_IsCompleted"
            set
            {
                //Setter Chamar a Notificação
                _isCompleted = value; // ( Ao setar ) No set de "IsCompleted" o valor é passado para "_IsCompleted"
                OnPropertyChanged(nameof(IsCompleted)); // Chama o método que avisa sobre a propriedade alterada. 
            }
        }
    }
}
