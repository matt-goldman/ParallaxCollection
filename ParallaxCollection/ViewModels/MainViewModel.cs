using System.Collections.ObjectModel;

namespace ParallaxCollection.ViewModels;

public partial class MainViewModel
{
    public ObservableCollection<HeroViewModel> Heroes { get; set; } =
    [
        new HeroViewModel()
        {
            Name = "Superman",
            SecretIdentity = "Clark Kent",
            HeroImage = "superman.png",
            LogoImage = "superman_logo.png",
            Background = Colors.Blue
        },
        new HeroViewModel()
        {
            Name = "Batman",
            SecretIdentity = "Bruce Wayne",
            HeroImage = "batman.png",
            LogoImage = "batman_logo.png",
            Background = Colors.DarkGray
        },
        new HeroViewModel()
        {
            Name = "Wonder Woman",
            SecretIdentity = "Diana Prince",
            HeroImage = "wonderwoman.png",
            LogoImage = "wonderwoman_logo.png",
            Background = Colors.Gold
        },
        new HeroViewModel()
        {
            Name = "The Flash",
            SecretIdentity = "Barry Allen",
            HeroImage = "theflash.png",
            LogoImage = "theflash_logo.png",
            Background = Colors.Red
        },
        new HeroViewModel()
        {
            Name = "Green Lantern",
            SecretIdentity = "Hal Jordan",
            HeroImage = "greenlantern.png",
            LogoImage = "greenlantern_logo.png",
            Background = Colors.Green
        },
        new HeroViewModel()
        {
            Name = "Shazam",
            SecretIdentity = "Billy Batson",
            HeroImage = "shazam.png",
            LogoImage = "shazam_logo.png",
            Background = Colors.Red
        }
    ];
}