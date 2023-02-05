using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Application
{
    public class EntriesService : MonoBehaviour, IDataContainer<EntriesData>
    {
        public event Action OnChange;

        private List<Entry> _entries = new List<Entry>();
        private System.Random _random;

		private void Start()
		{
            _random = new System.Random();
        }

		public void Add(string entry)
		{
            _entries.Add(new Entry { Name = entry });
            OnChange?.Invoke();
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

        public bool HasEntries()
		{
            return _entries.Count > 0;
        }

		void IDataContainer<EntriesData>.Set(EntriesData data)
		{
            _entries.Clear();
            _entries.AddRange(data.Entries.Select(entry => new Entry { Name = entry.Name }));
        }

		public EntriesData Get()
		{
            EntryData[] entryDatas = _entries.Select(entry => new EntryData { Name = entry.Name }).ToArray();
            return new EntriesData { Entries = entryDatas };
        }
	}
}
