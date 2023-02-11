using UnityEngine;

namespace Application
{
    public class InitialContentCreator : MonoBehaviour
    {
        [SerializeField]
        private SelectRandomEntryUI _selectEntryUIPrefab;
        [SerializeField]
        private ListOverviewUI _listOverviewUIPrefab;
		[SerializeField]
		private MainFrameUI _mainFrameUI;

		private void Start()
		{
			ListsService listsService = FindObjectOfType<ListsService>();
			ContentUI content = listsService.CurrentList != null ? CreateSelectRandomEntryUI() : CreateListsOverviewUI();
			_mainFrameUI.SetContent(content);
		}

		private ContentUI CreateSelectRandomEntryUI()
		{
			SelectRandomEntryUI content = Instantiate(_selectEntryUIPrefab);
			content.Create(_mainFrameUI);
			return content;
		}

		private ContentUI CreateListsOverviewUI()
		{
			ListOverviewUI content = Instantiate(_listOverviewUIPrefab);
			content.Create(_mainFrameUI);
			return content;
		}
	}
}
