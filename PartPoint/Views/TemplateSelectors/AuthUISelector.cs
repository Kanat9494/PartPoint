namespace PartPoint.Views.TemplateSelectors;

public class AuthUISelector : DataTemplateSelector
{
    public DataTemplate SignInTemplate { get; set; }
    public DataTemplate SignOutTemplate { get; set;}

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var title = item as string;
        if (title!.Equals("Вход"))
            return SignInTemplate;

        return SignOutTemplate;
    }
}
