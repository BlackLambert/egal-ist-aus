using SBaier.DI;
using UnityEngine;
using UnityEngine.UI;

namespace Application
{
    public class ChooseRandomEntryButton : MonoBehaviour, Injectable
    {
        [SerializeField]
        private Button _button;

		private EntriesService _entriesService;
		private Container<Entry> _entryContainer;

		public void Inject(Resolver resolver)
		{
			_entriesService = resolver.Resolve<EntriesService>();
			_entryContainer = resolver.Resolve<Container<Entry>>();
		}

		private void Start()
		{
			_button.onClick.AddListener(SelectRandom);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(SelectRandom);
		}

		private void SelectRandom()
		{
			_entryContainer.Store(_entriesService.GetRandom());
		}
	}
}
