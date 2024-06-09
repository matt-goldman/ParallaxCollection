using Microsoft.Maui.Handlers;

namespace ParallaxCollection.Controls;

public partial class ParallaxItemView
{
    protected PositionCalculatingView positionCalculatingView;

    partial void ConfigurePlatform()
    {
        _denominator = 3;
        CenterY = 160;

        ContentViewHandler.Mapper.AppendToMapping("parallax", (handler, view) =>
        {
            if (view is ParallaxItemView pView)
            {
                positionCalculatingView = new PositionCalculatingView
                {
                    ParentParallaxItemView = this
                };

                handler.PlatformView.AddSubview(positionCalculatingView);
            }
        });
    }

    partial void CalculateCentre()
    {
        positionCalculatingView.CalculatePosition();
        ThisCenter = PlatformY;
    }
}
