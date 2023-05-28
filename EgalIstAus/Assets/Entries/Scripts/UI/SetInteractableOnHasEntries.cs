using SBaier.DI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Application
{
    public class SetInteractableOnHasEntries : MonoBehaviour, Injectable
    {
        [SerializeField]
        private Button _button;

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
			_button.interactable = _entriesService.HasEntries;
		}
	}
}
