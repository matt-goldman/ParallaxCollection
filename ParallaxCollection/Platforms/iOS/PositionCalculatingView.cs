using UIKit;
using ParallaxCollection.Controls;

namespace ParallaxCollection;

public class PositionCalculatingView : UIView
{
    public ParallaxItemView ParentParallaxItemView { get; set; }

    public void CalculatePosition()
    {
        if (Superview != null)
        {
            var positionOnScreen = Superview.ConvertPointToView(Frame.Location, null);

            var newY = (int)positionOnScreen.Y;

            ParentParallaxItemView?.UpdatePosition(newY);
        }
    }
}
