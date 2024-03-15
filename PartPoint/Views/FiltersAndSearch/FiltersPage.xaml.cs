namespace PartPoint.Views.FiltersAndSearch;

public partial class FiltersPage : ContentPage
{
	public FiltersPage()
	{
		InitializeComponent();

		BindingContext = _viewModel = new FiltersViewModel();
	}

	FiltersViewModel _viewModel;

	void OnPickerSelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		var selectedItem = (Category)picker.SelectedItem;

		if (selectedItem != null)
		{
			if (selectedItem.CategoryId == 1)
			{
				_viewModel.InitializeAutoPartView();
			}
			else
			{
				_viewModel.InitializeTSSView();
			}
		}
	}

  //  protected override void OnNavigatedTo(NavigatedToEventArgs args)
  //  {
  //      base.OnNavigatedTo(args);

		//Shell.SetTabBarIsVisible(this, false);
  //  }
}