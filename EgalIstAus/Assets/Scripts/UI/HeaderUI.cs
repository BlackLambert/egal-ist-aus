using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class HeaderUI : ElementUI
	{
		[SerializeField]
		private string _titleID = "Title";
		private string _buttonContainerID = "ButtonContainer";

		private Label _title;
		private VisualElement _buttonContainer;

		private List<ElementUI> _buttons = new List<ElementUI>();

        public void SetTitle(string titleText)
		{
			_title.text = titleText;
		}

		public void Add(ElementUI button)
		{
			_buttons.Add(button);
			_buttonContainer.Add(button.RootElement);
			button.transform.SetParent(transform);
		}

		public void Remove(ElementUI button)
		{
			_buttons.Remove(button);
			_buttonContainer.Remove(button.RootElement);
		}

		protected override void Init()
		{
			FindUI();
			RegisterUI();
		}

		private void RegisterUI()
		{
			Frame.Instances.Register<HeaderUI, HeaderUI>(this);
		}

		private void FindUI()
		{
			_title = Q<Label>(_titleID);
			_buttonContainer = Q<VisualElement>(_buttonContainerID);
		}
	}
}
