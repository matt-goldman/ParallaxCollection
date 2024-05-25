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
}