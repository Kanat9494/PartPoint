namespace PartPoint.ViewModels.SelectPages;

internal class CarBrandsAndModelsViewModel : BaseViewModel
{
    public CarBrandsAndModelsViewModel(FiltersViewModel filtersViewModel)
    {
        IsCarBrandView = filtersViewModel._isCarBrandView;
        _filtersViewModel = filtersViewModel;
        CarBrands = new ObservableCollection<CarBrand>();
        CarModels = new ObservableCollection<CarModel>();
        CarBrandTapped = new AsyncRelayCommand<int>(OnCarBrand);
        CarModelCommand = new AsyncRelayCommand<int>(OnCarModel);
        if (IsCarBrandView)
            Task.Run(LoadCarBrands);
        else
            Task.Run(LoadCarModels);
    }

    private readonly FiltersViewModel _filtersViewModel;

    public ICommand CarBrandTapped { get; }
    public ICommand CarModelCommand { get; }

    public ObservableCollection<CarBrand> CarBrands { get; set; }
    public ObservableCollection<CarModel> CarModels { get; set; }

    private bool _isCarBrandView;
    public bool IsCarBrandView
    {
        get => _isCarBrandView;
        set => SetProperty(ref _isCarBrandView, value);
    }


    private async Task LoadCarBrands()
    {
        await Task.Delay(1000);
        for (int i = 0; i < 50; i++)
        {
            CarBrands.Add(new CarBrand
            {
                CarBrandId = i,
                Name = $"Toyota {i}"
            });
        }
    }

    async Task OnCarBrand(int carBrandId)
    {
        _filtersViewModel.SelectedCarBrand = new CarBrand
        {
            CarBrandId = carBrandId,
            Name = $"Toyota {carBrandId}",
            CategoryId = 1
        };
        await App.Current.MainPage.Navigation.PopModalAsync();
    }

    private async Task LoadCarModels()
    {
        await Task.Delay(1000);
        for (int i = 0; i < 50; i++)
        {
            CarModels.Add(new CarModel
            {
                CarModelId = i,
                Name = $"Avensis {i}",
                CarBrandId = _filtersViewModel.SelectedCarBrand.CarBrandId,
            });
        }
    }

    async Task OnCarModel(int carModelId)
    {
        _filtersViewModel.SelectedCarModel = new CarModel
        {
            CarModelId = carModelId,
            Name = $"Avensis {carModelId}",
            CarBrandId = _filtersViewModel.SelectedCarBrand.CarBrandId,
        };

        await App.Current.MainPage.Navigation.PopModalAsync();
    }
}
