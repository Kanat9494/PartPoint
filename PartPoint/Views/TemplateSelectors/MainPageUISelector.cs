namespace PartPoint.Views.TemplateSelectors;

public class MainPageUISelector : DataTemplateSelector
{
    public DataTemplate CategoriesTemplate { get; set; }
    public DataTemplate TopProductsTemplate { get; set; }
    public DataTemplate ProductsTemplate { get; set; }
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        //var listing = item as ContentList;
        //if (listing.Categories.Count > 0)
        //    return CategoriesTemplate;
        //else if (listing.TopProducts.Count > 0)
        //    return TopProductsTemplate;
        //else return ProductsTemplate;
        var product = item as Product;
        if (product.ProductId < 3)
            return CategoriesTemplate;
        else if (product.ProductId > 3 && product.ProductId < 10)
            return TopProductsTemplate;
        else return ProductsTemplate;
    }
}
