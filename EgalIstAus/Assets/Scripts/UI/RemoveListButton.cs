using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application
{
	public class RemoveListButton : BaseButton
	{
		[SerializeField]
		private ListsOverviewElement _element;
		private ListsService _listsService;

		protected override void Start()
		{
			_listsService = FindObjectOfType<ListsService>();
			base.Start();
		}

		protected override void OnClick()
		{
			_listsService.Remove(_element.List.Name);
		}
	}
}
