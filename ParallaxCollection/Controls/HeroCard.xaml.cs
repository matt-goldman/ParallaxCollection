using Maui.BindableProperty.Generator.Core;
using ParallaxCollection.Models;

namespace ParallaxCollection.Controls;

public partial class HeroCard : ParallaxItemView
{
    public HeroCard()
    {
        InitializeComponent();
        BindingContext = this;
        centreY = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density / 2;

    }

    private double _theY;

    public double TheY
    {
        get => _theY;
        set
        {
            _theY = value;
        }
    }

    double? top;
    double? bottom => top + this.Height;

    private double? _intitialCentre;

    private double centreY;

    double screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
    
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        if (BindingContext is not Hero hero) return;
        hero.OnCalculateOffset += OnCalculateOffset;
    }

    private void OnCalculateOffset(double yCenter, double scrollOffset)
    {
        if (this.Height == -1)
            return;

        if (top is null)
        {
            top = (this.GetScreenCoords().Y / DeviceDisplay.MainDisplayInfo.Density);
        }

        if (_intitialCentre is null)
        {
            _intitialCentre = top + (this.Height / 2);
        }

        if (bottom < 0 || top > screenHeight)
        {
            return;
        }

        top = top + scrollOffset;
        
        TheY = _intitialCentre.Value - scrollOffset - (centreY/20);


        double yOffset;
        if (TheY > yCenter)
        {
            yOffset = (yCenter - TheY) / 10;
            HeroImageImage.TranslationY = -yOffset;
        }
        else
        {
            yOffset = (TheY - yCenter) / 10;
            HeroImageImage.TranslationY = yOffset;
        }
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

    public static Point GetScreenCoords(this VisualElement view)
    {
        var result = new Point(view.X, view.Y);
        while (view.Parent is VisualElement parent)
        {
            result = result.Offset(parent.X, parent.Y);
            view = parent;
        }
        return result;
    }
}
