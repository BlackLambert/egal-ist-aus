using SBaier.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Application
{
    public class EntryViewsCreator : MonoBehaviour, Injectable
    {
		[SerializeField]
		private Transform _hook;

        private Factory<EntryView, Entry> _factory;
		private EntriesService _entriesService;
		private Dictionary<Entry, EntryView> _entryViews = new Dictionary<Entry, EntryView>(); 

		public void Inject(Resolver resolver)
		{
			_factory = resolver.Resolve<Factory<EntryView, Entry>>();
			_entriesService = resolver.Resolve<EntriesService>();
		}

		private void Start()
		{
			CreateEntryViews();
			_entriesService.OnEntriesSet += RecreateEntryViews;
			_entriesService.OnAdded += AddEntryView;
			_entriesService.OnRemoved += RemoveEntryView;
		}

		private void OnDestroy()
		{
			_entriesService.OnEntriesSet -= RecreateEntryViews;
			_entriesService.OnAdded -= AddEntryView;
			_entriesService.OnRemoved -= RemoveEntryView;
		}

		private void CreateEntryViews()
		{
			foreach (Entry entry in _entriesService.Entries)
			{
				AddEntryView(entry);
			}
		}

		private void ClearViews()
		{
			foreach(Entry entry in _entryViews.Keys.ToList())
			{
				RemoveEntryView(entry);
			}
		}

		private void AddEntryView(Entry entry)
		{
			EntryView view = _factory.Create(entry);
			view.transform.SetParent(_hook, false);
			_entryViews.Add(entry, view);
		}

		private void RemoveEntryView(Entry entry)
		{
			EntryView view = _entryViews[entry];
			Destroy(view.gameObject);
			_entryViews.Remove(entry);
		}

		private void RecreateEntryViews()
		{
			ClearViews();
			CreateEntryViews();
		}
	}
}
