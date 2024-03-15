namespace PartPoint.Views.Main;

public partial class MainPage : ContentPage
{
	public MainPage(IAuthService authService)
	{
		InitializeComponent();

		BindingContext = new MainViewModel(authService);
	}

	private void GoToSecondPage(object sender, EventArgs e)
	{
        Shell.Current.CustomShellMaui(new CustomShellMaui.Models.Transitions
        {
            Root = new CustomShellMaui.Models.TransitionRoot
            {
                CurrentPage = CustomShellMaui.Enum.TransitionType.FadeOut
            },
            Push = new CustomShellMaui.Models.Transition
            {
                CurrentPage = CustomShellMaui.Enum.TransitionType.None,
                NextPage = CustomShellMaui.Enum.TransitionType.ScaleOut
            },
            Pop = new CustomShellMaui.Models.Transition
            {
                CurrentPage = CustomShellMaui.Enum.TransitionType.ScaleIn,
                NextPage = CustomShellMaui.Enum.TransitionType.None
            }
        });

        Shell.Current.GoToAsync($"{nameof(FiltersPage)}");
    }
}