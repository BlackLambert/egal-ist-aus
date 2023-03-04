using UnityEngine;

namespace Application
{
	public class SelectRandomEntryUI : ElementUI, ContentUI
	{
		public Transform RootTransform => transform;

		public string Title => $"{_listsService.CurrentListName} - Choose Random Entry";
		private ListsService _listsService;

		protected override void Init()
		{
			_listsService = FindObjectOfType<ListsService>();
		}
	}
}
