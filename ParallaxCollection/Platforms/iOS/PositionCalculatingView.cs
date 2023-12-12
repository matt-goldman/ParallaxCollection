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
            var positionOnScreen = Superview.ConvertPointToView(Center, null);

            var newY = (int)positionOnScreen.Y;

            ParentParallaxItemView?.UpdatePosition(newY);
        }
    }
}
