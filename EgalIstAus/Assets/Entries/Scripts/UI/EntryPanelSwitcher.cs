using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application
{
    public class EntryPanelSwitcher : MonoBehaviour
    {
        [SerializeField]
        private List<EntryPanel> _panels;
		[SerializeField]
		private EntryPanelType _startPanel = EntryPanelType.CreateEntry;

		private void Start()
		{
			Show(_startPanel);
		}

		public void Show(EntryPanelType panelType)
		{
			foreach (EntryPanel panel in _panels)
			{
				panel.Show(panel.Type == panelType);
			}
		}
	}
}
