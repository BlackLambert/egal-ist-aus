using SBaier.DI;
using TMPro;
using UnityEngine;

namespace Application
{
    public class ListEntryView : MonoBehaviour, Injectable
    {
        [SerializeField]
        private TextMeshProUGUI _title;

		private EntryList _list;

		public void Inject(Resolver resolver)
		{
			_list = resolver.Resolve<EntryList>();
		}

		private void Start()
		{
			_title.text = _list.Name;
		}
	}
}
