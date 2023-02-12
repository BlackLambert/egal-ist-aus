using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Application
{
    public class ListsService : MonoBehaviour, IDataContainer<ListsData>
    {
        public event Action OnChange;
        public event Action<EntryList> OnAdded;
        public EntryList CurrentList { get; private set; }
        public string CurrentListName => CurrentList?.Name ?? string.Empty;

        private Dictionary<string, EntryList> _nameToList = new Dictionary<string, EntryList>();
        public IReadOnlyCollection<EntryList> Lists => _nameToList.Values;

		public void Add(string name)
        {
            EntryList list = new EntryList { Name = name };
            _nameToList.Add(name, list);
            OnChange?.Invoke();
            OnAdded?.Invoke(list);
        }

        public bool HasLists()
        {
            return _nameToList.Count > 0;
        }

        public bool HasList(string name)
        {
            return _nameToList.ContainsKey(name);
        }

        public void SetCurrentList(string name)
		{
            CurrentList = _nameToList[name];
        }

		void IDataContainer<ListsData>.Set(ListsData data)
		{
            _nameToList = data.Lists.Select( list => new EntryList { Name = list.Name }).ToDictionary(list => list.Name);
        }

		ListsData IDataContainer<ListsData>.Get()
		{
            List<ListData> listsData = _nameToList.Values.Select(list => new ListData { Name = list.Name }).ToList();
            return new ListsData { Lists = listsData };
		}

	}
}
