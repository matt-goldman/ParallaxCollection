using Maui.BindableProperty.Generator.Core;
using ParallaxCollection.ViewModels;

namespace ParallaxCollection.Controls;

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
        if (BindingContext is not HeroViewModel hero) return;
        //hero.OnHandleScrolled += OnScrolled;
    }

    public override void OnScrolled()
    {
        base.OnScrolled();
        HeroImageImage.TranslationY = ParallaxOffsetY;
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
