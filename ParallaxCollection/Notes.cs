// performant android method

public static class PositionHelpers
{
    public static double CentreY => DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density / 2;
}

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
        _viewModel.OnScrolled(e.FirstVisibleItemIndex, e.LastVisibleItemIndex, e.VerticalDelta);

        // NOTE: casting sender to IVisualTreeElement, then looping through and casting
        // visual children to HeroCard, then calling CalculateOffset and passing the delta
        // or offset works as well.
    }
}

public class ParallaxItemView : ContentView
{
    public ParallaxItemView()
    {
        Microsoft.Maui.Handlers.ContentViewHandler.Mapper.AppendToMapping("parallax", (handler, view) =>
        {
#if ANDROID
            if (view is ParallaxItemView pView)
            {
                handler.PlatformView.ViewTreeObserver!.ScrollChanged += (s, e) =>
                {
                    int[] location = new int[2];
                    handler.PlatformView.GetLocationOnScreen(location);
                    int x = location[0];
                    int y = location[1];

                    pView?.UpdatePosition(y);
                };
            }
#endif
        });
    }
    public void UpdatePosition(int y)
    {
        PlatformY = y;
    }

    private int _y;
    public int PlatformY
    {
        get => _y;
        set
        {
            _y = value;
            OnPropertyChanged(nameof(PlatformY));
        }
    }
}

public partial class HeroCard : ParallaxItemView
{
    public HeroCard()
    {
        InitializeComponent();
        BindingContext = this;
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        if (BindingContext is not Hero hero) return;
        hero.OnCalculateOffset += OnCalculateOffset;
    }

    private void OnCalculateOffset(double scrollOffset)//, int index)
    {
        if (Height == -1)
            return;

        var thisCentre = PlatformY + (Height / 2);

        var diff = thisCentre - PositionHelpers.CentreY;

        if (HeroName == "Batman")
            Console.WriteLine($"[{HeroName}] My centre: {thisCentre}, translationY: {diff}");

        HeroImageImage.TranslationY = diff / 10;
    }

    [AutoBindable(OnChanged = nameof(heroNameChanged))]
    private string heroName;
    private void heroNameChanged(string value)
    {
        HeroNameLabel.Text = value;
    }

    [AutoBindable(OnChanged = nameof(secretIdentityChanged))]
    private string secretIdentity;
    private void secretIdentityChanged(string value)
    {
        SecretIdentityLabel.Text = value;
    }

    [AutoBindable(OnChanged = nameof(heroLogoChanged))]
    private string heroLogo;
    private void heroLogoChanged(string value)
    {
        HeroLogoImage.Source = value;
    }

    [AutoBindable(OnChanged = nameof(heroImageChanged))]
    private string heroImage;
    private void heroImageChanged(string value)
    {
        HeroImageImage.Source = value;
    }

    [AutoBindable(OnChanged = nameof(backgroundChanged))]
    private Color background;
    private void backgroundChanged(Color value)
    {
        Card.Stroke = new SolidColorBrush(value);
        Card.BackgroundColor = value;
    }

    [AutoBindable]
    private bool isOnScreen;
}


/// new
/// 

namespace ParallaxCollection.Controls;

public class ParallaxCollectionView : CollectionView
{
    //private ParallaxItemView[] Items = [];

    protected override void OnScrolled(ItemsViewScrolledEventArgs e)
    {
        base.OnScrolled(e);
        var vte = (IVisualTreeElement)this;

        var visualItems = vte.GetVisualChildren()
            .Where(vi => vi is ParallaxItemView)
            .Select(vi => vi as ParallaxItemView)
            .ToArray();

        foreach (var item in visualItems)
        {
            item.OnScrolled();
        }
    }
}