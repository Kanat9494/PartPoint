namespace PartPoint.ViewModels.SelectPages;

internal class AutoPartsViewModel : BaseViewModel
{
    public AutoPartsViewModel(FiltersViewModel filtersViewModel)
    {
        _filtersViewModel = filtersViewModel;

        AutoParts = new ObservableCollection<AutoPart>();
        Task.Run(async () => await LoadAutoParts(_filtersViewModel.SelectedCarModel.CarModelId));
        AutoPartCommand = new AsyncRelayCommand<int>(OnAutoPart);
    }

    private readonly FiltersViewModel _filtersViewModel;

    public ICommand AutoPartCommand { get; }

    public ObservableCollection<AutoPart> AutoParts { get; set; }

    private async Task LoadAutoParts(int carModelId)
    {
        for (int i = 0; i < 50; i++)
        {
            AutoParts.Add(new AutoPart
            {
                AutoPartId = i,
                Name = $"Кузовные детали {i}",
                CarModelId = carModelId
            });
        }
    }

    async Task OnAutoPart(int autoPartId)
    {
        _filtersViewModel.SelectedAutoPart = new AutoPart
        {
            AutoPartId = autoPartId,
            Name = $"Кузовные детали {autoPartId}",
            CarModelId = 1
        };

        await App.Current.MainPage.Navigation.PopModalAsync();
    }
}
