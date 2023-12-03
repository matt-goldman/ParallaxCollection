using Maui.BindableProperty.Generator.Core;
using ParallaxCollection.Models;

namespace ParallaxCollection.Controls;

public partial class HeroCard : ContentView
{
    public HeroCard()
    {
        InitializeComponent();
    }

    private double _theY;

    public double TheY
    {
        get => _theY;
        set
        {
            _theY = value;
            YLabel.Text = value.ToString();
        }
    }

    private double? initialY;
    
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        if (BindingContext is not Hero hero) return;
        hero.OnCalculateOffset += OnCalculateOffset;
    }

    private void OnCalculateOffset(double yCenter, double scrollOffset)
    {
        if (initialY is null)
        {
            var ancestors = this.Ancestors();
            initialY = ancestors.Sum(a => a.Y);
        }
        
        TheY = initialY.Value - scrollOffset;
        
        double yOffset;
        if (TheY > yCenter)
        {
            yOffset = (yCenter - TheY) / 10;
        }
        else
        {
            yOffset = (TheY - yCenter) / 10;
        }
        
        HeroImageImage.TranslationY = yOffset;
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

public static class PositionHelpers
{
    public static IEnumerable<VisualElement> Ancestors(this VisualElement element)
    {
        while(element != null)
        {
            yield return element;
            element = element.Parent as VisualElement;
        }
    }
}