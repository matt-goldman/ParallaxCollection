using ParallaxCollection.ViewModels;

namespace ParallaxCollection.Pages;

public partial class HeroesPage : ContentPage
{
    private HeroesViewModel _viewModel;

    public HeroesPage()
    {
        InitializeComponent();
        _viewModel = new HeroesViewModel();
        BindingContext = _viewModel;
    }

    private void ItemsView_OnScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        _viewModel.OnScrolled(e.FirstVisibleItemIndex, e.LastVisibleItemIndex);
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        HeightLabel.Text = $"Height: {height}";
    }
}
