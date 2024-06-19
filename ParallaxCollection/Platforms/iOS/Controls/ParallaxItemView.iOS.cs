using CoreGraphics;
using UIKit;

namespace ParallaxCollection.Controls;

public partial class ParallaxItemView
{
    partial void ConfigurePlatform()
    {
        _denominator = 3;
        CenterY = 160;
    }

    partial void CalculateCentre()
    {
        CalculatePosition();
        ThisCenter = PlatformY;
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

        var locationCenterY = location.Y + (Height / 2);

        PlatformY = (int)(locationCenterY / _density);
    }
}
