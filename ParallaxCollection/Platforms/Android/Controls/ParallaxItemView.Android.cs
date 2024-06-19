using Microsoft.Maui.Handlers;

namespace ParallaxCollection.Controls;

public partial class ParallaxItemView
{
    partial void ConfigurePlatform()
    {
        _denominator = 10;
        CenterY = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density / 2;

        ContentViewHandler.Mapper.AppendToMapping("parallax", (handler, view) =>
        {
            if (view is ParallaxItemView pView)
            {
                handler.PlatformView.ViewTreeObserver!.ScrollChanged += (s, e) =>
                {
                    int[] location = new int[2];
                    handler.PlatformView.GetLocationOnScreen(location);
                    int x = location[0];
                    int y = location[1];

                    pView.PlatformY = y;
                };
            }
        });
    }

    partial void CalculateCentre()
    {
        ThisCenter = PlatformY + (Height / 2);
    }

    public void UpdatePlatformY(int y)
    {
        PlatformY = y;
    }
}
