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
		int selectedIndex = picker.SelectedIndex;

		if (selectedIndex != -1)
		{
			var text = picker.Items[selectedIndex];
			if (text == "Автозапчасти")
			{
				_viewModel.InitializeSubCategories(1, 1);
			}
		}
	}
}