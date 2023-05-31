using SBaier.DI;
using UnityEngine;
using UnityEngine.UI;

namespace Application
{
	public class DeleteEntryButton : MonoBehaviour, Injectable
    {
		[SerializeField]
		private Button _button;

		private Entry _entry;
		private EntriesService _entriesService;

		public void Inject(Resolver resolver)
		{
			_entry = resolver.Resolve<Entry>();
			_entriesService = resolver.Resolve<EntriesService>();
		}

		private void Start()
		{
			_button.onClick.AddListener(DeleteEntry);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(DeleteEntry);
		}

		private void DeleteEntry()
		{
			_entriesService.Remove(_entry);
		}
	}
}
