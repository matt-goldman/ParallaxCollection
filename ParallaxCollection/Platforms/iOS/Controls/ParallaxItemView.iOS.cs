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
        _platformView = this.Handler?.PlatformView as UIView;
    }

    private readonly double _density = DeviceDisplay.MainDisplayInfo.Density;
    private UIView _platformView;

    public void CalculatePosition()
    {
        var location = new CGPoint();
        if (_platformView != null)
        {
            location = _platformView.ConvertPointToView(_platformView.Bounds.Location, null);
        }

        var locationCenterY = location.Y + (Height / 2);

        PlatformY = (int)(locationCenterY / _density);
    }
}
