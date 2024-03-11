namespace PartPoint.ViewModels.FiltersAndSearch;

public class FiltersViewModel : BaseViewModel
{
    public FiltersViewModel()
    {
        IsAutoPartView = true;
        Categories = new ObservableCollection<Category>();
        CarBrands = new ObservableCollection<CarBrand>();
        CarModels = new ObservableCollection<CarModel>();
        AutoParts = new ObservableCollection<AutoPart>();

        SearchCommand = new AsyncRelayCommand(OnSearch);
        InitializeCategories();
    }

    public ICommand SearchCommand { get; }

    public ObservableCollection<Category> Categories { get; set; }
    public ObservableCollection<CarBrand> CarBrands { get; set; }
    public ObservableCollection<CarModel> CarModels { get; set; }
    public ObservableCollection<AutoPart> AutoParts { get; set; }


    private Category _selectedCategory;
    public Category SelectedCategory
    {
        get => _selectedCategory;
        set => SetProperty(ref _selectedCategory, value);
    }
    private bool _isAutoPartView;
    public bool IsAutoPartView
    {
        get => _isAutoPartView;
        set => SetProperty(ref _isAutoPartView, value);
    }
    private CarBrand _selectedCarBrand;
    public CarBrand SelectedCarBrand
    {
        get => _selectedCarBrand;
        set
        {
            if (_selectedCarBrand != value)
            {
                SetProperty(ref _selectedCarBrand, value);
                Task.Run(async () =>
                {
                    await LoadCarModels(value.CarBrandId);
                });
            }
        }
    }
    private CarModel _selectedCarModel;
    public CarModel SelectedCarModel
    {
        get => _selectedCarModel;
        set
        {
            if (_selectedCarModel != value)
            {
                SetProperty(ref _selectedCarModel, value);
                Task.Run(async () =>
                {
                    await LoadAutoParts(value.CarModelId);
                });
            }
        }
    }
    private AutoPart _selectedAutoPart;
    public AutoPart SelectedAutoPart
    {
        get => _selectedAutoPart;
        set
        {
            if (_selectedAutoPart != value)
            {
                SetProperty(ref _selectedAutoPart, value);
            }
        }
    }

    private void InitializeCategories()
    {
        Categories.Add(new Category
        {
            CategoryId = 1,
            Name = "Автозапчасти"
        });

        Categories.Add(new Category
        {
            CategoryId = 2,
            Name = "Услуги СТО"
        });
    }
    
    protected internal void InitializeAutoPartView()
    {
        IsAutoPartView = true;
        LoadCarBrands();
    }

    private void LoadCarBrands()
    {
        for (int i = 0; i < 50; i++)
        {
            CarBrands.Add(new CarBrand
            {
                CarBrandId = i,
                Name = $"Toyota {i}"
            });
        }
    }
    async Task LoadCarModels(int carBrandId)
    {
        for (int i = 0; i < 50; i++)
        {
            CarModels.Add(new CarModel
            {
                CarModelId = i,
                Name = $"Avensis {i}",
                CarBrandId = carBrandId
            });
        }
    }

    private async Task LoadAutoParts(int carModelId)
    {
        for (int i = 0; i < 50; i++)
        {
            AutoParts.Add(new AutoPart
            {
                AutoPartId = i,
                Name = $"Кузовные детали {i}",
                CarModelId = i
            });
        }
    }

    async Task OnSearch()
    {
        await Shell.Current.GoToAsync(nameof(SearchResultPage));
    }

    internal void InitializeTSSView()
    {
        IsAutoPartView = false;
    }
}
