using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMAUIGallery.ViewModels
{
    internal class SearchBarViewModel : INotifyPropertyChanged
    {
        private string _text;
        private string _statusLabel;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();

                // Atualiza o StatusLabel quando o texto muda
                StatusLabel = string.IsNullOrWhiteSpace(_text) ? string.Empty : $"Texto de busca: {_text}";
            }
        }

        public string StatusLabel
        {
            get => _statusLabel;
            set
            {
                _statusLabel = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClearTextCommand => new Command(() => Text = string.Empty);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
