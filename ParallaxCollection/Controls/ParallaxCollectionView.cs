namespace ParallaxCollection.Controls;

public class ParallaxCollectionView : CollectionView
{
    protected override void OnScrolled(ItemsViewScrolledEventArgs e)
    {
        base.OnScrolled(e);
        var vte = (IVisualTreeElement)this;

        var children = vte.GetVisualChildren();

        foreach (var child in children)
        {
            if (child is ParallaxItemView card)
            {
                card.OnScrolled();
            }
        }
    }
}
