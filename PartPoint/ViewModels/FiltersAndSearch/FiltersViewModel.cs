namespace PartPoint.ViewModels.FiltersAndSearch;

public class FiltersViewModel : BaseViewModel
{
    public FiltersViewModel()
    {
        IsAutoPartView = true;
        Categories = new ObservableCollection<Category>();
        SelectedCategory = new Category
        {
            CategoryId = 1,
            Name = "Автозапчасти"
        };
        SelectedCarBrand = new CarBrand
        {
            Name = "Марка авто"
        };
        SelectedCarModel = new CarModel
        {
            Name = "Модель авто"
        };
        SelectedAutoPart = new AutoPart
        {
            Name = "Запчасти"
        };
        CarModels = new ObservableCollection<CarModel>();
        AutoParts = new ObservableCollection<AutoPart>();

        SearchCommand = new AsyncRelayCommand(OnSearch);
        CarBrandsCommand = new AsyncRelayCommand(OnCarBrands);
        CarModelsCommand = new AsyncRelayCommand(OnCarModels);
        InitializeCategories();
    }

    public ICommand SearchCommand { get; }
    public ICommand CarBrandsCommand { get; }
    public ICommand CarModelsCommand { get; }

    protected internal bool _isCarBrandView;

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
        set => SetProperty(ref _selectedCarBrand, value);
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

    private async Task OnCarBrands()
    {
        _isCarBrandView = true;
        await App.Current.MainPage.Navigation.PushModalAsync(new CarBrandsAndModelsPage(this));
    }
    async Task OnCarModels()
    {
        if (SelectedCarBrand == null || SelectedCarBrand.CarBrandId == 0)
            return;
        _isCarBrandView = false;
        await App.Current.MainPage.Navigation.PushModalAsync(new CarBrandsAndModelsPage(this));
    }
}
