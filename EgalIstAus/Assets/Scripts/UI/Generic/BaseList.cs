using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public abstract class BaseList<TElementUI> : MonoBehaviour where TElementUI : ElementUI
    {
        [SerializeField]
        private int _elementHeight = 36;
        [SerializeField]
        protected BaseUI _ui;
        [SerializeField]
        private string _listID;

        protected ListView _list;
        protected abstract IList itemsList { get; }
        protected abstract TElementUI elementPrefab { get; }
        protected List<TElementUI> _elementsUI = new List<TElementUI>();

        protected virtual void Start()
		{
            _list = _ui.Q<ListView>(_listID);
            _list.selectionType = SelectionType.None;
            _list.fixedItemHeight = _elementHeight;
            _list.makeItem = MakeElement;
            _list.bindItem = BindElement;
            _list.itemsSource = itemsList;
        }

        protected abstract void BindElement(VisualElement element, int index);

        private VisualElement MakeElement()
        {
            TElementUI element = Instantiate(elementPrefab);
            _elementsUI.Add(element);
            element.transform.SetParent(transform);
            element.Create(_ui.Frame);
            return element.RootElement;
        }
    }
}
