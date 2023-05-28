using SBaier.DI;
using UnityEngine;
using UnityEngine.UI;

namespace Application
{
	public class ListSelectionButton : MonoBehaviour, Injectable
	{
		[SerializeField]
		private Button _button;

		private ListsService _listsService;
		private MainPanelSwitcher _panelSwitcher;
		private EntryList _list;

		public void Inject(Resolver resolver)
		{
			_listsService = resolver.Resolve<ListsService>();
			_panelSwitcher = resolver.Resolve<MainPanelSwitcher>();
			_list = resolver.Resolve<EntryList>();
		}

		private void Start()
		{
			_button.onClick.AddListener(SelectList);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(SelectList);
		}

		private void SelectList()
		{
			_listsService.SetCurrentList(_list);
			_panelSwitcher.Show(MainPanelType.Entries);
		}
	}
}
