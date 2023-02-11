using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
	public class SelectRandomEntryUI : ElementUI, ContentUI
	{
		[SerializeField]
		private string _selectRandomButtonID;
		[SerializeField]
		private string _addEntryButtonID;
		public Transform RootTransform => transform;

		public string Title => "Choose Random Entry";

		private Button _selectRandomButton;
		private Button _addEntryButton;

		protected override void Init()
		{
			_selectRandomButton = Q<Button>(_selectRandomButtonID);
			_addEntryButton = Q<Button>(_addEntryButtonID);
		}
	}
}
