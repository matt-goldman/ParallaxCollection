using Microsoft.Maui.Handlers;

namespace ParallaxCollection.Controls;

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