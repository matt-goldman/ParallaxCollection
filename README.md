# Parallax CollectionView

<div align="center">
  <img src="https://github.com/matt-goldman/ParallaxCollection/assets/19944129/6875a2d2-01ac-4953-b572-b240af2b7420" alt="An Android app displaying superheroes scrolling with a parallax effect" style="max-width: 300px;">
</div>

## About

This repository contains a sample demonstrating how to implement a parallax scrolling effect in a modified `CollectionView` in a .NET MAUI app. This project is part of [MAUI UI July 2024](https://goforgoldman.com/posts/mauiuijuly-24/).

Parallax is the appearance of things closer moving faster than things further away. In 2D games and UI design, it gives the illusion of depth and can make your apps come alive!

Feel free to explore the code, and for a full walkthrough of this implementation, check out the [blog post](https://goforgoldman.com/posts/parallax-collection/).

## Features

- **Parallax Scrolling Effect:** Adds a dynamic and visually appealing depth to your app's UI.
- **.NET MAUI ParallaxCollectionView:** Demonstrates the modification and extension of `CollectionView` into a `ParallaxCollectionView` control.
- **Cross-Platform:** Compatible with both Android and iOS.

## Usage

Replace an instance of `CollectionView` with `ParallaxCollectionView` (it's a subclass so you can do a straight substitution). In your `DataTemplate` use view that subclasses `ParallaxItemView` (this in turn subclasses `ContentView`). Override the `OnScrolled` method and set the `TranslationY` property of your foreground element to `ParallaxOffsetY`. This gets recalculated every time hte collection is scrolled.



---

Part of [MAUI UI July 2024](https://goforgoldman.com/posts/mauiuijuly-24/).

---

Cheers! 🍻
