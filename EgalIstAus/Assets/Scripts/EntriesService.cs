using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Application
{
    public class EntriesService : MonoBehaviour
    {
        private List<string> _entries = new List<string>();
        private System.Random _random;

		private void Start()
		{
            _random = new System.Random();
        }

		public void Add(string entry)
		{
            _entries.Add(entry);
        }

        public string GetRandom(string formerEntry = null)
		{
            bool filterEntries = formerEntry != null && _entries.Count > 0;
            List<string> selection = filterEntries ? 
                _entries.Where(entry => entry != formerEntry).ToList() : 
                _entries;
            int index = _random.Next(selection.Count);
            return selection[index];
        }

        public bool HasEntries()
		{
            return _entries.Count > 0;
        }
    }
}
