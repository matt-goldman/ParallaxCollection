#if IOS
using Foundation;
#endif

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

    public virtual void OnScrolled() { }
}
