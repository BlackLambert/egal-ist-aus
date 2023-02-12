using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class ListsOverviewList : MonoBehaviour
    {
        [SerializeField]
        private int _elementHeight = 36;
        [SerializeField]
        private BaseUI _ui;
        [SerializeField]
        private ListsOverviewElement _elementPrefab;
        [SerializeField]
        private string _listID;

        private ListsService _listsService;
        private ListView _list;
        private List<EntryList> _lists = new List<EntryList>();
        private List<ListsOverviewElement> _elements = new List<ListsOverviewElement>();

		private void Start()
		{
            _listsService = FindObjectOfType<ListsService>();
            _listsService.OnAdded += OnListAdded;
            _list = _ui.Q<ListView>(_listID);
            _list.selectionType = SelectionType.None;
            _lists.AddRange(_listsService.Lists);
            _list.fixedItemHeight = _elementHeight;
            _list.makeItem = MakeElement;
            _list.bindItem = BindElement;
            _list.itemsSource = _lists;
        }

		private void OnDestroy()
        {
            _listsService.OnAdded -= OnListAdded;
        }

		private void OnListAdded(EntryList list)
		{
            _lists.Add(list);
            _list.RefreshItems();
        }

        private VisualElement MakeElement()
        {
            ListsOverviewElement element = Instantiate(_elementPrefab);
            element.transform.SetParent(transform);
            element.Create(_ui.Frame);
            _elements.Add(element);
            return element.RootElement;
        }

        private void BindElement(VisualElement element, int index)
		{
            _elements[index].Init(_lists[index]);
		}
	}
}
