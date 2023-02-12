using UnityEngine;

namespace Application
{
	public class SelectListButton : BaseButton
	{
		[SerializeField]
		private ListsOverviewElement _overviewElement;
		[SerializeField]
		private SelectRandomEntryUI _selectRandomEntyUIPrefab;

		private ListsService _listsService;
		private ContentContainer _contentContainer;

		protected override void Start()
		{
			base.Start();
			_listsService = FindObjectOfType<ListsService>();
			_contentContainer = _ui.Instances.Get<ContentContainer>();
		}

		protected override void OnClick()
		{
			_listsService.SetCurrentList(_overviewElement.List.Name);
			OpenSelectRandomEntryView();
		}

		private void OpenSelectRandomEntryView()
		{
			SelectRandomEntryUI content = Instantiate(_selectRandomEntyUIPrefab);
			content.Create(_ui.Frame);
			_contentContainer.SetContent(content);
		}
	}
}
