using SBaier.DI;
using UnityEngine;
using UnityEngine.UI;

namespace Application
{
    public class SwitchEntryPanelButton : MonoBehaviour, Injectable
    {
        [SerializeField]
        private Button _button;
		[SerializeField]
		private EntryPanelType _type;

        private EntryPanelSwitcher _panelSwitcher;

		public void Inject(Resolver resolver)
		{
			_panelSwitcher = resolver.Resolve<EntryPanelSwitcher>();
		}

		private void Start()
		{
			_button.onClick.AddListener(ShowPanel);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(ShowPanel);
		}

		private void ShowPanel()
		{
			_panelSwitcher.Show(_type);
		}
	}
}
