namespace PartPoint.Views.SelectPages;

public partial class AutoPartsPage : ContentPage
{
	public AutoPartsPage(FiltersViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = new AutoPartsViewModel(viewModel);
	}
}