using System.Collections.ObjectModel;

namespace ParallaxCollection.Pages;

public partial class TestPage : ContentPage
{
    public ObservableCollection<string> Names { get; set; }

    public TestPage()
    {
        InitializeComponent();

        Names = new()
        {
            "1 Bob",
            "2 Frank",
            "3 Sarah",
            "4 Steven",
            "5 Alice",
            "6 John"
        };

        BindingContext = this;
    }
}
