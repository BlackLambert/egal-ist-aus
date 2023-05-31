using System;
using System.Collections.Generic;
using UnityEngine;

namespace Application
{
    public class EntryPanelSwitcher : MonoBehaviour
    {
        [SerializeField]
        private List<EntryPanel> _panels = new List<EntryPanel>();
		[SerializeField]
		private EntryPanelType _startPanel = EntryPanelType.CreateEntry;
		public EntryPanelType CurrentPanel { get; private set; }
		public Action OnPanelSwitched;

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
			CurrentPanel = panelType;
			OnPanelSwitched.Invoke();
		}
	}
}
