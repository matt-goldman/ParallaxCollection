using Microsoft.Maui.Controls.Internals;
using ParallaxCollection.ViewModels;

namespace ParallaxCollection;

public partial class MainPage : ContentPage
{
    private MainViewModel _viewModel;

    public MainPage()
    {
        InitializeComponent();
        _viewModel = new MainViewModel();
        BindingContext = _viewModel;
    }
}