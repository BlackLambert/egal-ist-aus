using SBaier.DI;
using System;
using UnityEngine;

namespace Application
{
    public class InitialEntryPanelSelector : MonoBehaviour, Injectable
    {
        private ListsService _listsService;
		private EntriesService _entriesService;
		private EntryPanelSwitcher _entryPanelSwitcher;

		public void Inject(Resolver resolver)
		{
			_listsService = resolver.Resolve<ListsService>();
			_entriesService = resolver.Resolve<EntriesService>();
			_entryPanelSwitcher = resolver.Resolve<EntryPanelSwitcher>();
		}

		private void Start()
		{
			_listsService.OnCurrentChange += ChoosePanel;
			ChoosePanel();
		}

		private void OnDestroy()
		{
			_listsService.OnCurrentChange -= ChoosePanel;
		}

		private void ChoosePanel()
		{
			if(_listsService.CurrentList == null || !_entriesService.HasEntries)
			{
				_entryPanelSwitcher.Show(EntryPanelType.CreateEntry);
			}
			else
			{
				_entryPanelSwitcher.Show(EntryPanelType.ChooseEntry);
			}
		}
	}
}
