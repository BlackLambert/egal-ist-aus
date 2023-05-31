using SBaier.DI;
using TMPro;
using UnityEngine;

namespace Application
{
    public class EntryNameDisplay : MonoBehaviour, Injectable
    {
        [SerializeField]
        private TextMeshProUGUI _text;

		private Entry _entry;

		public void Inject(Resolver resolver)
		{
			_entry = resolver.Resolve<Entry>();
		}

		private void Start()
		{
			_text.text = _entry.Name;
		}
	}
}
