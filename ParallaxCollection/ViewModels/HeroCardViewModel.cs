using ParallaxCollection.Models;

namespace ParallaxCollection.ViewModels;

public class HeroCardViewModel(Hero hero)
{
    public string Name { get; set; } = hero.Name;
    public string SecretIdentity { get; set; } = hero.SecretIdentity;
    public string HeroImage { get; set; } = hero.HeroImage;
    public string LogoImage { get; set; } = hero.LogoImage;
    public Color Background { get; set; } = hero.Background;
}