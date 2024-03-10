namespace PartPoint.ViewModels.FiltersAndSearch;

public class FiltersViewModel : BaseViewModel
{
    public FiltersViewModel()
    {
        Categories = new ObservableCollection<Category>()
        {
            
        };

        SelectCategoryCommand = new AsyncRelayCommand<int>(OnSelectCategory);
        SearchCommand = new AsyncRelayCommand(OnSearch);
    }

    public ICommand SelectCategoryCommand { get; }
    public ICommand SearchCommand { get; }

    private string _selectedCategory;
    public string SelectedCategory
    {
        get => _selectedCategory;
        set => SetProperty(ref _selectedCategory, value);
    }
    public ObservableCollection<Category> Categories { get; set; }

    internal protected void InitializeSubCategories(int level, int categoryId)
    {
        IsBusy = true;
        Categories.Clear();
        if (level == 1)
        {
            Categories.Add(new Category
            {
                CategoryId = 1,
                Name = "Все в категории авто",
                Level = 2
            });
        }
        else if (level == 2)
        {

        }
        for (int i = 0; i < 30; i++)
        {
            Categories.Add(new Category
            {
                CategoryId = i,
                Name = "Toyota",
                Level = 2
            });
        }
    }

    private async Task OnSelectCategory(int level)
    {
        if (level == 2)
        {
            Categories.Clear();

            Categories.Add(new Category
            {
                CategoryId = 1,
                Name = "Все в категории Toyota",
                Level = 3
            });

            for (int i = 0; i < 50; i++)
            {
                Categories.Add(new Category
                {
                    CategoryId = i,
                    Name = "Avensis",
                    Level = 3
                });
            }
        }
        else if (level == 3)
        {
            Categories.Clear();

            Categories.Add(new Category
            {
                CategoryId = 1,
                Name = "Все в категории Avensis",
                Level = 4
            });

            for (int i = 0; i < 50; i++)
            {
                Categories.Add(new Category
                {
                    CategoryId = i,
                    Name = "Кузовные детали",
                    Level = 4
                });
            }
        }
        else if (level == 4)
        {
            IsBusy = false;
        }
    }

    async Task OnSearch()
    {
        await Shell.Current.GoToAsync(nameof(SearchResultPage));
    }
}
