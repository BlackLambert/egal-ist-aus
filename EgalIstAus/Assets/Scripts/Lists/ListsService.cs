using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Application
{
    public class ListsService : MonoBehaviour, IDataContainer<ListsData>
    {
        public event Action OnChange;
        public EntryList CurrentList { get; private set; }
        public string CurrentListName => CurrentList?.Name ?? string.Empty;

        private List<EntryList> _lists = new List<EntryList>();

		public void Add(string name)
        {
            _lists.Add(new EntryList { Name = name });
            OnChange?.Invoke();
        }

        public bool HasLists()
        {
            return _lists.Count > 0;
        }

		void IDataContainer<ListsData>.Set(ListsData data)
		{
            _lists.Clear();
            _lists.AddRange(data.Lists.Select( list => new EntryList { Name = list.Name }));
        }

		ListsData IDataContainer<ListsData>.Get()
		{
            List<ListData> listsData = _lists.Select(list => new ListData { Name = list.Name }).ToList();
            return new ListsData { Lists = listsData };
		}

	}
}
