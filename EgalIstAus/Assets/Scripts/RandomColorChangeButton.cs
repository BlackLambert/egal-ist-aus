using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class RandomColorChangeButton : MonoBehaviour
    {
        [SerializeField]
        private UIDocument _document;
        [SerializeField]
        private string _buttonID;
        [SerializeField]
        private string _elementToColorID;
        [SerializeField]
        private List<Color> _colors = new List<Color>();

        private Button _button;
		private VisualElement _element;
		private System.Random _random;

		private void Start()
		{
			_random = new System.Random();
			_button = _document.rootVisualElement.Q<Button>(_buttonID);
			_element = _document.rootVisualElement.Q<VisualElement>(_elementToColorID);
			ValidateButtonExists();
			ValidateElementExists();
			_button.clicked += ChooseRandom;
		}

		private void OnDestroy()
		{
			if(_button != null)
			{
				_button.clicked -= ChooseRandom;
			}
		}

		private void ChooseRandom()
		{
			int index = _random.Next(_colors.Count);
			Color color = _colors[index];
			_element.style.backgroundColor = color;
		}

		private void ValidateElementExists()
		{
			if (_element == null)
			{
				throw new ArgumentException($"Button with ID {_elementToColorID} not found");
			}
		}

		private void ValidateButtonExists()
		{
			if (_button == null)
			{
				throw new ArgumentException($"Button with ID {_buttonID} not found");
			}
		}
	}
}