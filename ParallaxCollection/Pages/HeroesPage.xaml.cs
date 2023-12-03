using ParallaxCollection.ViewModels;

namespace ParallaxCollection.Pages;

public partial class HeroesPage : ContentPage
{
    public double YHeight { get; set; }
    
    public HeroesPage()
    {
        InitializeComponent();
        BindingContext = new HeroesViewModel();
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        YHeight = height;
    }

    private void ItemsView_OnScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        //HeroesCollection.Items
    }
}