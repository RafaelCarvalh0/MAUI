using Android.Health.Connect.DataTypes.Units;
using AppJogoForca.Models;
using AppJogoForca.Repositories;
using Microsoft.Maui.Controls.Internals;
using System.ComponentModel;

namespace AppJogoForca
{
    public partial class MainPage : ContentPage
    {
        private readonly IWordRepository _wordRepository;
        private Word _word;
        private int _errors;

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
                LblText.Text = string.Empty;

                _word = await _wordRepository.GetRandomWordSync();
                LblTips.Text = _word.Tips;

                for (int i = 0; i < _word.Text.Length; i++)
                {
                    LblText.Text = new String('_', _word.Text.Length);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"{ex.Message}", "OK");
            }
        }

        private async void CharacterHandle(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            char ch = Convert.ToChar(btn.Text);

            if (!_word.Text.Contains(ch))
            {            
                LblText.TextColor = Color.FromArgb("#E74D3C");              
                btn.BackgroundColor = Color.FromArgb("#E74D3C");
                _errors++;
                ImgMain.Source = ImageSource.FromFile($"forca{_errors + 1}.png");

                if(_errors == 6)
                {
                    await DisplayAlert("Perdeu!", "Você foi enforcado!", "New game");
                    ClearStates();
                    GetWord();
                }
            }
            else
            {
                for (int i = 0; i < _word.Text.Length; i++)
                {
                    if (ch == _word.Text[i])
                    {
                        LblText.TextColor = Color.FromArgb("#1BB45C");
                        btn.BackgroundColor = Color.FromArgb("#1BB45C");
                        LblText.Text = LblText.Text.Remove(i, 1).Insert(i, ch.ToString());
                    }
                }
            }

            btn.IsEnabled = false;
        }

        private void wordHandle(object sender, EventArgs e)
        {          
            ClearStates();
            GetWord();
        }

        private void ClearStates()
        {
            _errors = 0;
            ImgMain.Source = ImageSource.FromFile("forca1.png");
            LblText.TextColor = Color.FromRgb(0, 0, 0);

            foreach (Button button in GetAllButtons(container))
            {
                button.IsEnabled = true;
                button.TextColor = Colors.Black;
                button.BackgroundColor = Color.FromRgb(255, 255, 255);
            }
        }

        private IEnumerable<Button> GetAllButtons(Layout container)
        {
            foreach (var child in container.Children)
            {
                if (child is Button button)
                {
                    yield return button;
                }

                if (child is Layout layout)
                {
                    foreach (var nestedButton in GetAllButtons(layout))
                    {
                        yield return nestedButton;
                    }
                }
            }
        }
    }
}
