using AppMAUIGallery.Resources.Styles;

namespace AppMAUIGallery.Views.Styles;

public partial class Theme : ContentPage
{
	private bool Light = true;
	public Theme()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		ICollection<ResourceDictionary> dictionaries = Application.Current.Resources.MergedDictionaries;

		if(dictionaries is not null)
		{
			dictionaries.Remove(dictionaries.ElementAt(3));

			if (Light)
			{
				Light = !Light;
				dictionaries.Add(new DarkTheme());
			}
			else
			{
                Light = !Light;
                dictionaries.Add(new LightTheme());
            }
		}
    }
}