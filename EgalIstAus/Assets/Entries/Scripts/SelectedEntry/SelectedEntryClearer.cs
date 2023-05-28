using SBaier.DI;
using System;
using UnityEngine;

namespace Application
{
    public class SelectedEntryClearer : MonoBehaviour, Injectable
    {
        private Container<Entry> _entryContainer;
		private ListsService _listsService;

		public void Inject(Resolver resolver)
		{
			_entryContainer = resolver.Resolve<Container<Entry>>();
			_listsService = resolver.Resolve<ListsService>();
		}

		private void Start()
		{
			_listsService.OnCurrentChange += ClearEntryContainer;
		}

		private void OnDestroy()
		{
			_listsService.OnCurrentChange -= ClearEntryContainer;
		}

		private void ClearEntryContainer()
		{
			_entryContainer.Store(null);
		}
	}
}
