using CoreGraphics;
using Foundation;
using UIKit;

namespace ParallaxCollection;

public class ObserverView : UIView
{
    public Action<int> PositionChanged { get; set; }
    private bool isObserving = false;
    private NSString keyPath;

    public void StartObserving(UIView targetView, NSString keyPath)
    {
        Console.WriteLine("[ObserverView]StartObserving");
        this.keyPath = keyPath;
        targetView.AddObserver(this, keyPath, NSKeyValueObservingOptions.New, IntPtr.Zero);
        isObserving = true;
    }

    public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, nint context)
    {
        Console.WriteLine("[ObserverView]ObserveValue");
        if (keyPath == this.keyPath)
        {
            Console.WriteLine("[ObserverView]Frame changed");
            var newFrame = (NSValue)change.ObjectForKey(NSValue.ChangeNewKey);
            if (newFrame != null)
            {
                var frameValue = newFrame.CGRectValue;
                var view = ofObject as UIView;
                var positionOnScreen = view?.ConvertRectToView(frameValue, null).Location ?? CGPoint.Empty;
                PositionChanged?.Invoke((int)positionOnScreen.Y);
            }
        }

        base.ObserveValue(keyPath, ofObject, change, context);
    }


    protected override void Dispose(bool disposing)
    {
        if (disposing && isObserving)
        {
            Console.WriteLine("[ObserverView]Dispose");
            // Assuming the observed view is the superview. Adjust if necessary.
            this.Superview?.RemoveObserver(this, keyPath);
            isObserving = false;
        }

        base.Dispose(disposing);
    }
}
