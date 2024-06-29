namespace ParallaxCollection.Controls
{
    public class ParallaxCollectionView : CollectionView
    {
        private readonly List<ParallaxItemView> _parallaxItemViews = new List<ParallaxItemView>();

        protected override void OnScrolled(ItemsViewScrolledEventArgs e)
        {
            base.OnScrolled(e);
            foreach (var item in _parallaxItemViews)
            {
                item?.OnScrolled();
            }
        }

        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
            if (child is ParallaxItemView parallaxItemView)
            {
                _parallaxItemViews.Add(parallaxItemView);
            }
        }

        protected override void OnChildRemoved(Element child, int oldIndex)
        {
            base.OnChildRemoved(child, oldIndex);
            if (child is ParallaxItemView parallaxItemView)
            {
                _parallaxItemViews.Remove(parallaxItemView);
            }
        }
    }
}
