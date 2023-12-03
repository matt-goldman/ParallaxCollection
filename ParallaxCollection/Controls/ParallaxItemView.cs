using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace ParallaxCollection.Controls;

public class ParallaxItemView : ContentView
{
    
}

public class ParallaxItemViewHandler : ContentViewHandler
{
    public ParallaxItemViewHandler() : base(Mapper)
    {
    }

    protected override ContentViewGroup CreatePlatformView()
    {
#if _ANDROID_
        return base.CreatePlatformView();
#elif _IOS_ || _MACCATALYST_
        return base.CreatePlatformView();
#elif _WINDOWS_
      return base.CreatePlatformView();
#else
        return base.CreatePlatformView();
#endif
        
    }
}