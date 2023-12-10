using CommunityToolkit.Mvvm.ComponentModel;

namespace ParallaxCollection.ViewModels;

[ObservableObject]
public partial class ParallaxViewModel
{
    public delegate void CalculateOffset(double scrollOffset);//, int index);
    
    [ObservableProperty]
    private bool isOnScreen;

    public event CalculateOffset? OnCalculateOffset;
    public virtual void OnScrolled(double scrollOffset)//, int index)
    {
        OnCalculateOffset?.Invoke(scrollOffset);//, index);
    }
}