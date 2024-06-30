namespace ParallaxCollection.Controls;

public partial class ParallaxItemView
{
    partial void ConfigurePlatform()
    {
        CenterY = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density / 2;
        _denominator = 10;

        Microsoft.Maui.Handlers.ContentViewHandler.Mapper.AppendToMapping("parallax", (handler, view) =>
        {
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
        });
    }

    partial void CalculateCenter()
    {
        ThisCenter = PlatformY + (Height / 2);
    }

    public void UpdatePosition(int y)
    {
        PlatformY = y;
    }
}
