using Android.Health.Connect.DataTypes.Units;
using AppJogoForca.Models;
using AppJogoForca.Repositories;

namespace AppJogoForca
{
    public partial class MainPage : ContentPage
    {
        private readonly IWordRepository _wordRepository;
        public MainPage()
        {
            InitializeComponent();
            _wordRepository = MauiProgram.Services.GetRequiredService<IWordRepository>();

            GetWord();
        }

        private async void GetWord()
        {
            try
            {
                Word word = await _wordRepository.GetWordSync();
                dicaField.Text = word.Tips;

                for(int i = 0; i < word.Text.Length; i++)
                {
                    wordField.Text += "_ ";
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
