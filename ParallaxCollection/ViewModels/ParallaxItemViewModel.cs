using CommunityToolkit.Mvvm.ComponentModel;

namespace ParallaxCollection.ViewModels;

public partial class ParallaxItemViewModel : ObservableObject
{
    public delegate void CalculateOffset();

    public event CalculateOffset? OnCalculateOffset;
    public virtual void OnScrolled()
    {
        OnCalculateOffset?.Invoke();
    }
}
