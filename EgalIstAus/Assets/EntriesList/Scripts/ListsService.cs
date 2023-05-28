using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class ListsService : DataContainer<ListsData>, ElementsContainer<EntryList>
    {
        public event Action OnChange;
        public event Action OnCurrentChange;
        public event Action<EntryList> OnAdded;
		public event Action<EntryList> OnRemoved;

		public EntryList CurrentList { get; private set; }
        public string CurrentListName => CurrentList?.Name ?? string.Empty;

        private Dictionary<string, EntryList> _nameToList = new Dictionary<string, EntryList>();
        public IReadOnlyCollection<EntryList> Lists => _nameToList.Values;
		IReadOnlyCollection<EntryList> ElementsContainer<EntryList>.Elements => _nameToList.Values;

		public void Add(string name)
        {
            EntryList list = new EntryList { Name = name };
            _nameToList.Add(name, list);
            OnChange?.Invoke();
            OnAdded?.Invoke(list);
        }

        public void Remove(string name)
		{
            EntryList list = _nameToList[name];
            _nameToList.Remove(name);
            OnChange?.Invoke();
            OnRemoved?.Invoke(list);
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
            SetCurrentList(_nameToList[name]);
        }

        public void SetCurrentList(EntryList list)
		{
            CurrentList = list;
            OnCurrentChange?.Invoke();
        }

        void DataContainer<ListsData>.SetDefault()
        {
            _nameToList.Clear();
        }

        void DataContainer<ListsData>.Set(ListsData data)
		{
            _nameToList = data.Lists.Select( list => new EntryList { Name = list.Name }).ToDictionary(list => list.Name);
        }

		ListsData DataContainer<ListsData>.Get()
		{
            List<ListData> listsData = _nameToList.Values.Select(list => new ListData { Name = list.Name }).ToList();
            return new ListsData { Lists = listsData };
		}
	}
}
