using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ParallaxCollection.Models;

namespace ParallaxCollection.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        SeedHeroes();
    }
    
    public ObservableCollection<HeroCardViewModel> Heroes { get; set; } = new();

    public void OnScrolled(int firstItemIndex, int lastItemIndex)
    {
        for (var i = firstItemIndex; i <= lastItemIndex; i++)
        {
            var hero = Heroes[i];

            hero.OnScrolled();
        }
    }
    
    private void SeedHeroes()
    {
        foreach (var hero in _heroes)
        {
            Heroes.Add(new HeroCardViewModel(hero));
        }
    }
    
    private List<Hero> _heroes { get; set; } = new()
    {
        new Hero()
        {
            Name = "Superman",
            SecretIdentity = "Clark Kent",
            HeroImage = "superman.png",
            LogoImage = "superman_logo.png",
            Background = Colors.Blue
        },
        new Hero()
        {
            Name = "Batman",
            SecretIdentity = "Bruce Wayne",
            HeroImage = "batman.png",
            LogoImage = "batman_logo.png",
            Background = Colors.DarkGray
        },
        new Hero()
        {
            Name = "Wonder Woman",
            SecretIdentity = "Diana Prince",
            HeroImage = "wonderwoman.png",
            LogoImage = "wonderwoman_logo.png",
            Background = Colors.Gold
        },
        new Hero()
        {
            Name = "The Flash",
            SecretIdentity = "Barry Allen",
            HeroImage = "theflash.png",
            LogoImage = "theflash_logo.png",
            Background = Colors.Red
        },
        new Hero()
        {
            Name = "Green Lantern",
            SecretIdentity = "Hal Jordan",
            HeroImage = "greenlantern.png",
            LogoImage = "greenlantern_logo.png",
            Background = Colors.Green
        },
        new Hero()
        {
            Name = "Shazam",
            SecretIdentity = "Billy Batson",
            HeroImage = "shazam.png",
            LogoImage = "shazam_logo.png",
            Background = Colors.Red
        }
    };
}
