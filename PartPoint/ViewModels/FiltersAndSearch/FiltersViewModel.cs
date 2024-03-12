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

        SearchCommand = new AsyncRelayCommand(OnSearch);
        CarBrandsCommand = new AsyncRelayCommand(OnCarBrands);
        CarModelsCommand = new AsyncRelayCommand(OnCarModels);
        AutoPartCommand = new AsyncRelayCommand(OnAutoPart);
        InitializeCategories();
    }

    public ICommand SearchCommand { get; }
    public ICommand CarBrandsCommand { get; }
    public ICommand CarModelsCommand { get; }
    public ICommand AutoPartCommand { get; }

    protected internal bool _isCarBrandView;

    public ObservableCollection<Category> Categories { get; set; }


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
        set => SetProperty(ref _selectedCarModel, value);
    }
    private AutoPart _selectedAutoPart;
    public AutoPart SelectedAutoPart
    {
        get => _selectedAutoPart;
        set => SetProperty(ref _selectedAutoPart, value);
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

    private async Task OnAutoPart()
    {
        if (SelectedCarModel == null || SelectedCarModel.CarModelId == 0)
            return;

        await App.Current.MainPage.Navigation.PushModalAsync(new AutoPartsPage(this));
    }
}
