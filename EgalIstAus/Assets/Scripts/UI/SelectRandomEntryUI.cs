using UnityEngine;

namespace Application
{
	public class SelectRandomEntryUI : ElementUI, ContentUI
	{
		[SerializeField]
		private string _selectRandomButtonID;
		[SerializeField]
		private string _addEntryButtonID;
		public Transform RootTransform => transform;

		public string Title => $"{_listsService.CurrentListName} - Choose Random Entry";
		private ListsService _listsService;

		protected override void Init()
		{
			_listsService = FindObjectOfType<ListsService>();
		}
	}
}
