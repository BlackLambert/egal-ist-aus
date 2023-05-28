using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application
{
    public class MainPanelSwitcher : MonoBehaviour
    {
        [SerializeField]
        private List<MainPanel> _panels = new List<MainPanel>();
		[SerializeField]
		private MainPanelType _startPanel = MainPanelType.Lists;

		private void Start()
		{
			Show(_startPanel);
		}

		public void Show(MainPanelType panelType)
		{
			foreach (MainPanel panel in _panels)
			{
				panel.Show(panel.Type == panelType);
			}
		}
    }
}
