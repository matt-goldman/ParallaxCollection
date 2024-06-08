using CoreGraphics;
using UIKit;
using ParallaxCollection.Controls;

namespace ParallaxCollection;

public class PositionCalculatingView : UIView
{
    public ParallaxItemView ParentParallaxItemView { get; set; }

    private readonly double _density = DeviceDisplay.MainDisplayInfo.Density;

    public void CalculatePosition()
    {
        {   
            var location = new CGPoint();
            var view = ParentParallaxItemView.Handler?.PlatformView as UIView;
            if (view != null)
            {
                location = view.ConvertPointToView(view.Bounds.Location, null);
            }
            
            var locationCenterY = location.Y + (ParentParallaxItemView.Height / 2);

            ParentParallaxItemView.PlatformY = (int)(locationCenterY / _density);
        }
    }
}
