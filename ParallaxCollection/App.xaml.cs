using ParallaxCollection.Pages;

namespace ParallaxCollection;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new HeroesPage();
    }
}