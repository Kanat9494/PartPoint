
namespace PartPoint.Views.SelectPages;

public partial class CarBrandsAndModelsPage : ContentPage
{
	public CarBrandsAndModelsPage(FiltersViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = new CarBrandsAndModelsViewModel(viewModel);
	}
}