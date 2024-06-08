using Maui.BindableProperty.Generator.Core;
using ParallaxCollection.Helpers;
using ParallaxCollection.ViewModels;

namespace ParallaxCollection.Controls;

public partial class HeroCard : ParallaxItemView
{
    int denominator;

    public HeroCard()
    {
        InitializeComponent();
        BindingContext = this;

#if ANDROID
        denominator = 10;
#elif IOS
        denominator = 3;
#endif
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        if (BindingContext is not HeroCardViewModel hero) return;
        hero.OnCalculateOffset += OnCalculateOffset;
    }

    private void OnCalculateOffset()
    {
        if (Height == -1)
            return;

        double thisCentre = 0;
#if IOS
        positionCalculatingView.CalculatePosition();
        thisCentre = PlatformY;
#elif ANDROID
        thisCentre = PlatformY + (Height / 2);
#endif

        var diff = thisCentre - PositionHelpers.CentreY;

        var transY = diff / denominator;
        HeroImageImage.TranslationY = transY;
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
}
