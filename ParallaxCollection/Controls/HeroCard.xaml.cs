using Maui.BindableProperty.Generator.Core;

namespace ParallaxCollection.Controls;

public partial class HeroCard : ContentView
{
    public HeroCard()
    {
        InitializeComponent();
    }
    
    // [AutoBindable(OnChanged = nameof(yHeightChanged))]
    // private double _yHeight;
    // private void yHeightChanged(double value)
    // {;
    // }
    //
    // [AutoBindable(OnChanged = nameof(yCentreChanged))]
    // private double yCentre;
    // private void yCentreChanged(double value)
    // {
    //     
    // }
    
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
    
    [AutoBindable(OnChanged = nameof(imageChanged))]
    private string image;
    private void imageChanged(string value)
    {
        HeroImage.Source = value;
    }
    
    [AutoBindable(OnChanged = nameof(backgroundChanged))]
    private Color background;
    private void backgroundChanged(Color value)
    {
        Card.Stroke = new SolidColorBrush(value);
        Card.BackgroundColor = value;
    }
}