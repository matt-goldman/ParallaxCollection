#if IOS
using Foundation;
#endif

using ParallaxCollection.Helpers;

namespace ParallaxCollection.Controls;

public abstract class ParallaxItemView : ContentView
{
#if IOS
    protected PositionCalculatingView positionCalculatingView;
#endif
    public ParallaxItemView()
    {

        Microsoft.Maui.Handlers.ContentViewHandler.Mapper.AppendToMapping("parallax", (handler, view) =>
        {
            if (view is ParallaxItemView pView)
            {
#if ANDROID
                handler.PlatformView.ViewTreeObserver!.ScrollChanged += (s, e) =>
                {
                    int[] location = new int[2];
                    handler.PlatformView.GetLocationOnScreen(location);
                    int x = location[0];
                    int y = location[1];

                    pView?.UpdatePosition(y);
                };
#elif IOS
                positionCalculatingView = new PositionCalculatingView
                {
                    ParentParallaxItemView = this
                };

                handler.PlatformView.AddSubview(positionCalculatingView);
#endif
            }
        });

#if ANDROID
        _denominator = 10;
#elif IOS
        _denominator = 3;
#endif
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
            OnPropertyChanged();
        }
    }

    private int _denominator;

    protected double ParallaxOffsetY;

    public virtual void OnScrolled()
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

        ParallaxOffsetY = diff / _denominator;
    }
}
