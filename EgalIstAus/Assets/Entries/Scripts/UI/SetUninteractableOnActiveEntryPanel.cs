using SBaier.DI;
using UnityEngine;

namespace Application
{
    public class SetUninteractableOnActiveEntryPanel : MonoBehaviour, Injectable
    {
        [SerializeField]
        private InteractableSwitcher _interactableSwitcher;
		[SerializeField]
		private EntryPanelType panelType;

		private EntryPanelSwitcher _panelSwitcher;

		public void Inject(Resolver resolver)
		{
			_panelSwitcher = resolver.Resolve<EntryPanelSwitcher>();
		}

		private void Start()
		{
			UpdateInteractable();
			_panelSwitcher.OnPanelSwitched += UpdateInteractable;
		}

		private void Reset()
		{
			_interactableSwitcher = GetComponent<InteractableSwitcher>();
		}

		private void OnDestroy()
		{
			_panelSwitcher.OnPanelSwitched -= UpdateInteractable;
		}

		private void UpdateInteractable()
		{
			_interactableSwitcher.SetInteracable(this, _panelSwitcher.CurrentPanel != panelType);
		}
	}
}
