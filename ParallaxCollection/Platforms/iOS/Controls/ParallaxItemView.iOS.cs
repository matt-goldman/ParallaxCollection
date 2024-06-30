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
        CalculatePosition();
        ThisCenter = _platformY + (Height / 2);
    }

    private readonly double _density = DeviceDisplay.MainDisplayInfo.Density;

    private void CalculatePosition()
    {
        var location = new CGPoint();
        if (this.Handler?.PlatformView is UIView platformView)
        {
            location = platformView.ConvertPointToView(platformView.Bounds.Location, null);
        }

        _platformY = (int)(location.Y / _density);
    }
}
