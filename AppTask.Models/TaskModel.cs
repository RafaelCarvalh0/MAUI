using System.ComponentModel;

namespace AppTask.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
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
        public required List<SubTaskModel> SubTasks { get; set; }
        public class SubTaskModel 
        {
            public int Id { get; set; }
            public required string Name { get; set; }
            public bool IsCompleted { get; set; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            //Apenas para garantir que não irá cair em exception de null
            if (PropertyChanged is not null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
