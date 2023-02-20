using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class ListsOverviewList : ContainerItemList<EntryList, ListsOverviewElement>
    {
        [SerializeField]
        private ListsOverviewElement _elementPrefab;
        protected override ListsOverviewElement elementPrefab => _elementPrefab;

        protected override void BindElement(VisualElement element, int index)
		{
            _elementsUI[index].Init(_elements[index]);
        }

		protected override ElementsContainer<EntryList> GetContainer()
		{
            return FindObjectOfType<ListsService>();
        }
	}
}
