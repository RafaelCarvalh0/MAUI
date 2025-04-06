using Microsoft.Maui.Controls.Internals;
using AppMAUIGallery.Helpers;
namespace AppMAUIGallery.Views.Cells;

public partial class ViewCellPage : ContentPage
{
    public ViewCellPage()
    {
        InitializeComponent();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        ImageButton btn = ((ImageButton)sender);

        //Tem certeza que Grid é Pai de Button
        //Grid grid = (Grid)btn.Parent;

        //Se não tiver certeza, faz uma busca recursiva
        Grid grid = Helpers.Helpers.FindParent<Grid>(btn);
        ViewCell viewCell = Helpers.Helpers.FindParent<ViewCell>(grid);

        // Remove a ViewCell correspondente da seção
        if (viewCell is not null && MyTableSection.Contains(viewCell))
        {
            MyTableSection.Remove(viewCell);
        }
    }
}
