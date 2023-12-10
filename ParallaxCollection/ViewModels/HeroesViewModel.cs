using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ParallaxCollection.Models;

namespace ParallaxCollection.ViewModels;

[ObservableObject]
public partial class HeroesViewModel
{
    private List<string> HeroesOnScreen = new();

    [ObservableProperty]
    private string heroesList;
    public ObservableCollection<Hero> Heroes { get; set; } = new()
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

    public void OnScrolled(int firstItemIndex, int lastItemIndex, double verticalOffset)
    {
        for (var i = firstItemIndex; i <= lastItemIndex; i++)
        {
            var hero = Heroes[i];
            
            hero.OnScrolled(verticalOffset);//, i);
        }
    }
    
    // public void OnScrolled(double scrollOffset)
    // {
    //     for (int i = 0; i < Heroes.Count; i++)
    //     {
    //         var hero = Heroes[i];
    //         hero.OnScrolled(scrollOffset, i);
    //
    //         if (hero.IsOnScreen)
    //         {
    //             if (!HeroesOnScreen.Contains(hero.Name))
    //             {
    //                 HeroesOnScreen.Add(hero.Name);
    //                 Console.WriteLine($"{hero.Name} appeared on screen");
    //             }
    //         }
    //         else
    //         {
    //             if (HeroesOnScreen.Contains(hero.Name))
    //             {
    //                 HeroesOnScreen.Remove(hero.Name);
    //                 Console.WriteLine($"{hero.Name} left the screen");
    //             }
    //         }
    //     }
    //
    //     HeroesList = $"Heroes on screen:{Environment.NewLine}{HeroesOnScreen.Count}";
    //     foreach (var hero in HeroesOnScreen)
    //     {
    //         HeroesList += $"{hero},";
    //     }
    // }
}