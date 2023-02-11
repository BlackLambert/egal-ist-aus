using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class RandomColorChangeButton : MonoBehaviour
    {
        [SerializeField]
        private BaseUI _ui;
        [SerializeField]
        private string _buttonID;
        [SerializeField]
        private string _elementToColorID;
        [SerializeField]
        private List<Color> _colors = new List<Color>();

        private Button _button;
		private VisualElement _element;
		private System.Random _random;
		private Color currentColor = Color.black;

		private void Start()
		{
			_random = new System.Random();
			_button = _ui.Q<Button>(_buttonID);
			_element = _ui.Q<VisualElement>(_elementToColorID);
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
			List<Color> colors = _colors.Where(color => color != currentColor).ToList();
			int index = _random.Next(colors.Count);
			currentColor = colors[index];
			_element.style.backgroundColor = currentColor;
		}
	}
}