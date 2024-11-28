using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{
	private readonly ICategoryRepository _categoryRepository;

    public Menu()
    {
        InitializeComponent();
        _categoryRepository = MauiProgram.Services.GetRequiredService<ICategoryRepository>();

        GetCategories();
    }

    public Menu(ICategoryRepository categoryRepository)
	{
        InitializeComponent();
        _categoryRepository = categoryRepository;

		GetCategories();
	}

    private async void GetCategories()
    {
		try
		{
            var categories = await _categoryRepository.GetCategories();

            foreach (var category in categories)
            {
                var lblCategory = new Label();
                lblCategory.Text = category.Name;

                MenuContainer.Children.Add(lblCategory);

                foreach(var component in category.Components)
                {
                    var lblComponentTitle = new Label();    
                    lblComponentTitle.Text = component.Title;

                    var lblComponentDescription = new Label();  
                    lblComponentDescription.Text = component.Description;

                    MenuContainer.Children.Add(lblComponentTitle);  
                    MenuContainer.Children.Add(lblComponentDescription);  
                }
            }
        }
		catch (Exception ex)
		{

			throw;
		}
    }
}