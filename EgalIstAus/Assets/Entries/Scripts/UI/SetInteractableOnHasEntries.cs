using SBaier.DI;
using UnityEngine;

namespace Application
{
    public class SetInteractableOnHasEntries : MonoBehaviour, Injectable
    {
        [SerializeField]
        private InteractableSwitcher _interactableSwitcher;

		private EntriesService _entriesService;
		private ListsService _listsService;

		public void Inject(Resolver resolver)
		{
			_entriesService = resolver.Resolve<EntriesService>();
			_listsService = resolver.Resolve<ListsService>();
		}

		private void Start()
		{
			UpdateInteractable();
			_entriesService.OnChange += UpdateInteractable;
			_listsService.OnCurrentChange += UpdateInteractable;
		}

		private void OnDestroy()
		{
			_entriesService.OnChange -= UpdateInteractable;
			_listsService.OnCurrentChange -= UpdateInteractable;
		}

		private void UpdateInteractable()
		{
			_interactableSwitcher.SetInteracable(this, _entriesService.HasEntries);
		}
	}
}
