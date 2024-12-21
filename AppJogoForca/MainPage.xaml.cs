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

            SetTextColorBasedOnTheme();
            GetWord();
        }

        private void SetTextColorBasedOnTheme()
        {
            if (Application.Current.RequestedTheme == AppTheme.Dark)
                LblText.TextColor = Colors.White;
            else
                LblText.TextColor = Colors.Black;
        }

        private async void GetWord()
        {
            try
            {
                LblText.Text = string.Empty;
                _word = await _wordRepository.GetRandomWordSync();
                LblTips.Text = _word.Tips;

                for (int i = 0; i < _word.Text.Length; i++) LblText.Text = new String('_', _word.Text.Length);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"{ex.Message}", "OK");
            }
        }

        private async void CharacterHandle(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;

            char ch = Convert.ToChar(btn.Text);

            if (!_word.Text.Contains(ch))
            {
                ErrorHandle(btn);
                await IsGameOver();
                return;
            }

            for (int i = 0; i < _word.Text.Length; i++)
            {
                if (ch == _word.Text[i])
                    SuccessHandle(btn, ch, i);
            }

            await HasWinner();
        }

        private void RestartHandle(object sender, EventArgs e)
        {
            ClearStates();
            GetWord();
        }

        #region Handler Success
        private void SuccessHandle(Button btn, char ch, int i)
        {
            btn.Style = App.Current.Resources.MergedDictionaries.ElementAt(1)["Success"] as Style;
            LblText.Text = LblText.Text.Remove(i, 1).Insert(i, ch.ToString());
        }

        private async Task HasWinner()
        {
            if (LblText.Text.Replace("_", "").Length == _word.Text.Length) //!LblText.Text.Contains("_")
            {
                await DisplayAlert("Parabéns!", "Você ganhou o jogo!", "New game");
                ClearStates();
                GetWord();
            }
        }

        #endregion

        #region Handler Error

        private void ErrorHandle(Button btn)
        {
            btn.Style = App.Current.Resources.MergedDictionaries.ElementAt(1)["Fail"] as Style;
            _errors++;
            ImgMain.Source = ImageSource.FromFile($"forca{_errors + 1}.png");
        }

        private async Task IsGameOver()
        {
            if (_errors == 6)
            {
                await DisplayAlert("Perdeu!", "Você foi enforcado!", "New game");
                ClearStates();
                GetWord();
            }
        }

        #endregion

        #region Clear States

        private void ClearStates()
        {
            _errors = 0;
            ImgMain.Source = ImageSource.FromFile("forca1.png");
            SetTextColorBasedOnTheme();

            foreach (Button button in GetAllButtons(container))
            {
                button.IsEnabled = true;
                button.Style = null;
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

        #endregion
    }
}
