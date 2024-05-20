namespace ParallaxCollection.Helpers;

public static class PositionHelpers
{
    public static double CentreY
    {
        get
        {
            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                return DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density / 2;
            }
            else if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
            {
                return 160;
            }
            else
            {
                throw new InvalidOperationException("Unsupported platform");
            }
        }
    }
    
    // public static IEnumerable<VisualElement> Ancestors(this VisualElement element)
    // {
    //     while(element != null)
    //     {
    //         yield return element;
    //         element = element.Parent as VisualElement;
    //     }
    // }
    //
    // public static Point GetScreenCoords(this VisualElement view)
    // {
    //     var result = new Point(view.X, view.Y);
    //
    //     bool foundParent = false;
    //     
    //     while (view.Parent is VisualElement parent)
    //     {
    //         result = result.Offset(parent.X, parent.Y);
    //         view = parent;
    //         foundParent = true;
    //     }
    //     
    //     Console.WriteLine($"Found parent: {foundParent}");
    //     
    //     return result;
    // }
}