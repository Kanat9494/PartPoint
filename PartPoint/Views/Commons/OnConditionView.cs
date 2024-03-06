namespace PartPoint.Views.Commons;

public class OnConditionView : ContentView
{
    public static readonly BindableProperty OnConditionProperty =
        BindableProperty.Create(nameof(OnCondition), typeof(bool), typeof(OnConditionView), false, propertyChanged: OnContentDependentPropertyChanged);

    public bool OnCondition
    {
        get => (bool)GetValue(OnConditionProperty);
        set => SetValue(OnConditionProperty, value);
    }

    public static readonly BindableProperty BuildViewProperty =
        BindableProperty.Create(nameof(BuildView), typeof(View), typeof(OnConditionView), null, propertyChanged: OnContentDependentPropertyChanged);
    public View BuildView
    {
        get => (View)GetValue(BuildViewProperty);
        set => SetValue(BuildViewProperty, value);
    }

    public static readonly BindableProperty DestroyViewProperty =
        BindableProperty.Create(nameof(DestroyView), typeof(View), typeof(OnConditionView), null, propertyChanged: OnContentDependentPropertyChanged);
    public View DestroyView
    {
        get => (View)GetValue(DestroyViewProperty);
        set => SetValue(DestroyViewProperty, value);
    }

    private static void OnContentDependentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        OnConditionView? onCV = bindable as OnConditionView;
        onCV?.UpdateContent();
    }

    private void UpdateContent()
    {
        if (OnCondition)
        {
            Content = BuildView;
        }
        else
        {
            Content = DestroyView;
        }
    }
}
