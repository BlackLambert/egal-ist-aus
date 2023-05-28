using SBaier.DI;
using System;
using UnityEngine;

namespace Application
{
    public class ListEntryViewsCreator : MonoBehaviour, Injectable
    {
		[SerializeField]
		private RectTransform _hook;

		private ListsService _listsService;
		private Factory<ListEntryView, EntryList> _factory;


		public void Inject(Resolver resolver)
		{
			_listsService = resolver.Resolve<ListsService>();
			_factory = resolver.Resolve<Factory<ListEntryView, EntryList>>();
		}

		private void Start()
		{
			CreateEntries();
		}

		private void CreateEntries()
		{
			foreach (EntryList list in _listsService.Lists)
			{
				ListEntryView entry = _factory.Create(list);
				entry.transform.SetParent(_hook, false);
			}
		}
	}
}
