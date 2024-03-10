namespace PartPoint.ViewModels.FiltersAndSearch;

public class SearchResultViewModel : BaseViewModel
{
    public SearchResultViewModel()
    {
        Products = new ObservableCollection<Product>();

        Task.Run(InitializeSearchResult);
    }

    public ObservableCollection<Product> Products { get; set; }

    private async Task InitializeSearchResult()
    {
        IsBusy = true;
        await Task.Delay(3500);


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
}
