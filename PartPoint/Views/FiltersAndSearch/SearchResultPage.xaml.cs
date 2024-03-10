namespace PartPoint.Views.FiltersAndSearch;

public partial class SearchResultPage : ContentPage
{
	public SearchResultPage()
	{
		InitializeComponent();

		BindingContext = new SearchResultViewModel();
	}
}