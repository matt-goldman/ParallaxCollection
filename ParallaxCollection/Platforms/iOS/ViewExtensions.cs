using Microsoft.Maui.Platform;
using UIKit;

namespace ParallaxCollection;

public static class ViewExtensions
{
    public static UIView GetNativeView(this Page page)
    {
        if (page?.Handler?.MauiContext != null)
        {
            return page.ToPlatform(page.Handler.MauiContext);
        }
        
        return null;
    }
    
    public static UIView GetTopmostView()
    {
        var keyWindow = UIApplication.SharedApplication.KeyWindow;
        if (keyWindow != null && keyWindow.WindowLevel == UIWindowLevel.Normal)
        {
            return keyWindow;
        }

        foreach (var window in UIApplication.SharedApplication.Windows)
        {
            if (window.WindowLevel == UIWindowLevel.Normal)
            {
                return window;
            }
        }

        return null;
    }
}