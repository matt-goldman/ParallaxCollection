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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnScrolled(0);
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        _viewModel.yCenter = height / 2;
    }

    private void ItemsView_OnScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        _viewModel.OnScrolled(e.FirstVisibleItemIndex, e.LastVisibleItemIndex);
    }

    private void TheScroll_OnScrolled(object sender, ScrolledEventArgs e)
    {
        _viewModel.OnScrolled(e.ScrollY);
    }
}