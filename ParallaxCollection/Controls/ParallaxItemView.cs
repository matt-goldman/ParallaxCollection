using Android.Content;
using Android.Runtime;
using Android.Util;

using Microsoft.Maui.Platform;


using Microsoft.Maui.Handlers;

namespace ParallaxCollection.Controls;

public class ParallaxItemView : ContentView
{
    public void UpdatePosition(int y)
    {
        PlatformY = y;
    }

    private int _y;
    public int PlatformY
    {
        get => _y;
        set
        {
            _y = value;
            Console.WriteLine($"PlatformY: {value}");
            OnPropertyChanged(nameof(PlatformY));
        }
    }
}

public class ParallaxItemViewHandler : ContentViewHandler
{
    public ParallaxItemViewHandler() : base(Mapper)
    {
    }


    public override void SetVirtualView(IView view)
    {
        base.SetVirtualView(view);

        var _piView = (ParallaxItemView)view;

        if (PlatformView is ContentViewGroup contentViewGroup)
        {
            contentViewGroup.ViewTreeObserver.GlobalLayout += (s, e) =>
            {
                int[] location = new int[2];
                contentViewGroup.GetLocationOnScreen(location);
                int x = location[0];
                int y = location[1];

                _piView?.UpdatePosition(y);
            };
        }
    }
}