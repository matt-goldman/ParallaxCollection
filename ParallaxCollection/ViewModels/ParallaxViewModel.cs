using CommunityToolkit.Mvvm.ComponentModel;

namespace ParallaxCollection.ViewModels;

[ObservableObject]
public partial class ParallaxViewModel
{
    public delegate void CalculateOffset(double yCentre, double scrollOffset);

    public event CalculateOffset? OnCalculateOffset;
    public virtual void OnScrolled(double yCentre, double scrollOffset)
    {
        OnCalculateOffset?.Invoke(yCentre, scrollOffset);
    }
}