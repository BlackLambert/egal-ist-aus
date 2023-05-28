using SBaier.DI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class EntriesService : DataContainer<EntriesData>, ElementsContainer<Entry>, Injectable
    {
        public event Action OnChange;
        public event Action<Entry> OnAdded;
		public event Action<Entry> OnRemoved;

        public IReadOnlyList<Entry> Entries => _entries.AsReadOnly();
        public bool HasEntries => Amount > 0;
        public int Amount => _entries.Count;
        private List<Entry> _entries = new List<Entry>();
        private System.Random _random;

		IReadOnlyCollection<Entry> ElementsContainer<Entry>.Elements => _entries;

        public void Inject(Resolver resolver)
        {
            _random = resolver.Resolve<Random>();
        }

		public void Add(string entryName)
		{
            Entry entry = new Entry { Name = entryName };
            _entries.Add(entry);
            OnChange?.Invoke();
            OnAdded?.Invoke(entry);
        }

		public void Remove(string entryName)
		{
            Entry entry = _entries.First(element => element.Name == entryName);
            _entries.Remove(entry);
            OnChange?.Invoke();
            OnRemoved?.Invoke(entry);
        }

        public Entry GetRandom(IEnumerable<Entry> formerEntries = null)
		{
            bool filterEntries = formerEntries != null && _entries.Count > 1;
            List<Entry> selection = filterEntries ? 
                _entries.Except(formerEntries).ToList() : 
                _entries;
            int index = _random.Next(selection.Count);
            return selection[index];
        }

        public bool HasEntry(string name)
        {
            return _entries.Any(entry => entry.Name == name);
        }

        public void Clear()
        {
            _entries.Clear();
            OnChange?.Invoke();
        }

        public EntriesData Get()
        {
            EntryData[] entryDatas = _entries.Select(entry => new EntryData { Name = entry.Name }).ToArray();
            return new EntriesData { Entries = entryDatas };
        }

        void DataContainer<EntriesData>.Set(EntriesData data)
		{
            _entries.Clear();
            _entries.AddRange(data.Entries.Select(entry => new Entry { Name = entry.Name }));
        }

        void DataContainer<EntriesData>.SetDefault()
        {
            _entries.Clear();
        }
	}
}
