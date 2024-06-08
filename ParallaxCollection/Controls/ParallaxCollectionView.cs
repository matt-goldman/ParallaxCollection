namespace ParallaxCollection.Controls;

public class ParallaxCollectionView : CollectionView
{
    protected override void OnScrolled(ItemsViewScrolledEventArgs e)
    {
        base.OnScrolled(e);

        var vte = (IVisualTreeElement)this;

        var visualItems = vte.GetVisualChildren();

        foreach (var item in visualItems)
        {
            if (item is ParallaxItemView parallaxItem)
            {
                parallaxItem.OnScrolled();
            }
        }
    }
}
