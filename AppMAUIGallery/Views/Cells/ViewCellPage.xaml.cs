using Microsoft.Maui.Controls.Internals;

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

        //Tem certeza que Grid � Pai de Button
        //Grid grid = (Grid)btn.Parent;

        //Se n�o tiver certeza, faz uma busca recursiva
        Grid grid = Utils.Utils.FindParent<Grid>(btn);
        ViewCell viewCell = Utils.Utils.FindParent<ViewCell>(grid);

        // Remove a ViewCell correspondente da se��o
        if (viewCell is not null && MyTableSection.Contains(viewCell))
        {
            MyTableSection.Remove(viewCell);
        }
    }
}
