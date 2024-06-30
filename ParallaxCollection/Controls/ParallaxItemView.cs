namespace ParallaxCollection.Controls;

public partial class ParallaxItemView : ContentView
{
    private int _y;
    private int _denominator;
    protected double ParallaxOffsetY;
    private double ThisCenter;
    private double CenterY;

    public int PlatformY
    {
        get => _y;
        set
        {
            _y = value;
            OnPropertyChanged(nameof(PlatformY));
        }
    }

    public ParallaxItemView()
    {
        ConfigurePlatform();
    }

    public virtual void OnScrolled()
    {
        if (Height == -1)
            return;

        CalculateCenter();

        var diff = ThisCenter - CenterY;
        ParallaxOffsetY = diff / _denominator;
    }

    partial void ConfigurePlatform();
    partial void CalculateCenter();

    
}