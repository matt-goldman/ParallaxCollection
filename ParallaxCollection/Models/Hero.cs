using ParallaxCollection.ViewModels;

namespace ParallaxCollection.Models;

public class Hero : ParallaxViewModel
{
    public string Name { get; set; }
    public string SecretIdentity { get; set; }
    public string HeroImage { get; set; }
    public string LogoImage { get; set; }
    public Color Background { get; set; }
}