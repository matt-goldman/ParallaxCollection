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

    // protected override void OnAppearing()
    // {
    //     base.OnAppearing();
    //     _viewModel.OnScrolled(0);
    // }

    private void ItemsView_OnScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        _viewModel.OnScrolled(e.FirstVisibleItemIndex, e.LastVisibleItemIndex, e.VerticalDelta);
    }

    // private void TheScroll_OnScrolled(object sender, ScrolledEventArgs e)
    // {
    //     _viewModel.OnScrolled(e.ScrollY);
    // }
}