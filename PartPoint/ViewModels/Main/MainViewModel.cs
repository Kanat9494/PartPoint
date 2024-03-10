namespace PartPoint.ViewModels.Main;

public class MainViewModel : BaseViewModel
{
    public MainViewModel(IAuthService authService)
    {
        _authService = authService;
        _authService.IsUserAuthenticated();
        
        Products = new ObservableCollection<Product>();
        TopProducts = new ObservableCollection<TopProduct>();
        Categories = new ObservableCollection<Category>();
        FilterCommand = new AsyncRelayCommand(OnFilter);


        Task.Run(InitializeContent);
    }

    private readonly IAuthService _authService;

    public ICommand FilterCommand { get; }

    public ObservableCollection<Product> Products { get; set; }
    public ObservableCollection<TopProduct> TopProducts { get; set; }
    public ObservableCollection<Category> Categories { get; set; }

    private async Task InitializeContent()
    {
        IsBusy = true;
        await Task.Delay(3000);

        Categories.Add(new Category
        {
            CategoryId = 1,
            Name = "Автозапчасти"
        });
        Categories.Add(new Category
        {
            CategoryId = 1,
            Name = "Услуги СТО"
        });

        for (int i = 0; i < 9; i++)
        {
            TopProducts.Add(new TopProduct
            {
                ImageUrl = $"https://picsum.photos/id/{i}/200/300"
            });
        }

        
        for (int i = 0; i < 100; i++)
        {
            Products.Add(new Product
            {
                ProductId = i,
                Title = "Lorem Ipsum",
                Price = i * 100,
                ImageUrl = $"https://picsum.photos/id/{i}/200/300"
            });
        }

        IsBusy = false;
    }

    async Task OnFilter()
    {
        await Shell.Current.GoToAsync($"{nameof(FiltersPage)}");
    }
}
