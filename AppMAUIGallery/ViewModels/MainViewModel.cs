using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Input;

namespace AppMAUIGallery.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
                IsClearButtonVisible = !string.IsNullOrWhiteSpace(_text);
            }
        }

        private bool _isClearButtonVisible;
        public bool IsClearButtonVisible
        {
            get => _isClearButtonVisible;
            set
            {
                _isClearButtonVisible = value;
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
