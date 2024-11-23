namespace AppNumeroDaSorte;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void OnGenerateNumbers(object sender, EventArgs e)
    {
        //((Button)sender).Text = "";
        AppName.IsVisible = false;
        ContainerNumbers.IsVisible = true;
        //CleanNumbers();

        var set = GenerateNumbers();

        Number01.Text = set.ElementAt(0).ToString("D2");
        Number02.Text = set.ElementAt(1).ToString("D2");
        Number03.Text = set.ElementAt(2).ToString("D2");
        Number04.Text = set.ElementAt(3).ToString("D2");
        Number05.Text = set.ElementAt(4).ToString("D2");
        Number06.Text = set.ElementAt(5).ToString("D2");
    }

    private SortedSet<int> GenerateNumbers()
    {
        //SortedSet
        var set = new SortedSet<int>();
        while (set.Count < 6)
        {
            var random = new Random();
            var number = random.Next(1, 60);

            set.Add(number);
        }  
        return set;
    }

    private void CleanNumbers()
    {
        Number01.Text = string.Empty;
        Number02.Text = string.Empty;
        Number03.Text = string.Empty;
        Number04.Text = string.Empty;
        Number05.Text = string.Empty;
        Number06.Text = string.Empty;
    }
}