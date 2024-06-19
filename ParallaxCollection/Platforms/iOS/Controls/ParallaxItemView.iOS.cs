using CoreGraphics;
using UIKit;

namespace ParallaxCollection.Controls;

public partial class ParallaxItemView
{
    partial void ConfigurePlatform()
    {
        _denominator = 3;
        CenterY = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density / 2;
    }

    partial void CalculateCentre()
    {
        ThisCenter = PlatformY + (Height / 2);
    }

    private readonly double _density = DeviceDisplay.MainDisplayInfo.Density;

    public void CalculatePosition()
    {
        var location = new CGPoint();
        var platformView = this.Handler?.PlatformView as UIView;
        if (platformView != null)
        {
            location = platformView.ConvertPointToView(platformView.Bounds.Location, null);
        }

        PlatformY = (int)(location.Y / _density);
    }
}
