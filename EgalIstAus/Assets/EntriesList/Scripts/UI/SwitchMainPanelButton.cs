using SBaier.DI;
using UnityEngine;
using UnityEngine.UI;

namespace Application
{
    public class SwitchMainPanelButton : MonoBehaviour, Injectable
    {
        [SerializeField]
        private Button _button;
		[SerializeField]
		private MainPanelType _type;

        private MainPanelSwitcher _panelSwitcher;

		public void Inject(Resolver resolver)
		{
			_panelSwitcher = resolver.Resolve<MainPanelSwitcher>();
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
