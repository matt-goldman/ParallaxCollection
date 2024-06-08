namespace ParallaxCollection.Controls;

public class ParallaxCollectionView : CollectionView
{
    protected override void OnScrolled(ItemsViewScrolledEventArgs e)
    {
        base.OnScrolled(e);

        var vte = (IVisualTreeElement)this;

        var items = vte.GetVisualTreeDescendants();

        var visualItems = vte.GetVisualChildren();

        foreach (var item in visualItems)
        {
            if (item is ParallaxItemView parallaxItem)
            {
                parallaxItem.OnScrolled();
            }
            else
            {
                var itemType = item.GetType();
                Console.WriteLine($"[ParallaxCollectionView] item type is {itemType.Name}");
            }
        }
    }
}
