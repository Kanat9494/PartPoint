namespace PartPoint.ViewModels.FiltersAndSearch;

public class FiltersViewModel : BaseViewModel
{
    public FiltersViewModel()
    {
        IsAutoPartView = true;
        Categories = new ObservableCollection<Category>();
        Filters = new ObservableCollection<Category>();

        SearchCommand = new AsyncRelayCommand(OnSearch);
        InitializeCategories();
    }

    public ICommand SearchCommand { get; }

    public ObservableCollection<Category> Categories { get; set; }
    public ObservableCollection<Category> Filters { get; set; }


    private Category _selectedCategory;
    public Category SelectedCategory
    {
        get => _selectedCategory;
        set 
        { 
            if (value.CategoryId == 1)
            {
                try
                {
                    IsAutoPartView = true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                SetProperty(ref _selectedCategory, value);
            }
            else
            {
                IsAutoPartView = false;
                SetProperty(ref _selectedCategory, value);
            }
        }
    }
    private bool _isAutoPartView;
    public bool IsAutoPartView
    {
        get => _isAutoPartView;
        set => SetProperty(ref _isAutoPartView, value);
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
}
