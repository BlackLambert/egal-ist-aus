using System;
using System.Collections;
using System.Collections.Generic;

namespace Application
{
    public abstract class ContainerItemList<TElement, TElementUI> : BaseList<TElementUI> where TElementUI : ElementUI
    {
        protected override IList itemsList => _elements;
        private ElementsContainer<TElement> container;
        protected List<TElement> _elements = new List<TElement>();

		protected override void Start()
        {
            container = GetContainer();
            container.OnAdded += OnAdded;
            container.OnRemoved += OnRemoved;
            _elements.AddRange(container.Elements);
            base.Start();
        }

		private void OnDestroy()
        {
            container.OnAdded -= OnAdded;
            container.OnRemoved -= OnRemoved;
        }

        protected abstract ElementsContainer<TElement> GetContainer();

        private void OnAdded(TElement element)
        {
            _elements.Add(element);
            _list.RefreshItems();
        }

        private void OnRemoved(TElement element)
        {
            int index = _elements.IndexOf(element);
            TElementUI elementUI = _elementsUI[index];
            Destroy(elementUI.gameObject);
            _elementsUI.RemoveAt(index);
            _elements.Remove(element);
            _list.RefreshItems();
        }
    }
}
