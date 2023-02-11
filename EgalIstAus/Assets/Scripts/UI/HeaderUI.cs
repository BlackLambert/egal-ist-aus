using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class HeaderUI : ElementUI
	{
		[SerializeField]
		private string _titleID = "Title";

		private Label _title;

        public void SetTitle(string titleText)
		{
			_title.text = titleText;
		}

		protected override void Init()
		{
			FindUI();
			RegisterUI();
			AddListeners();
		}

		private void RegisterUI()
		{
			Frame.Instances.Register<HeaderUI, HeaderUI>(this);
		}

		private void FindUI()
		{
			_title = Q<Label>(_titleID);
		}

		private void AddListeners()
		{
			
		}
	}
}
