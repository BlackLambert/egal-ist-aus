using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class EntryAdder : MonoBehaviour
    {
        [SerializeField]
        private UIDocument _document;
        [SerializeField]
        private string _buttonID;
        [SerializeField]
        private string _inputID;

        private Button _button;
        private TextField _input;
		private EntriesService _entriesService;

        private void Start()
		{
			_button = _document.rootVisualElement.Q<Button>(_buttonID);
			_input = _document.rootVisualElement.Q<TextField>(_inputID);
			_entriesService = FindObjectOfType<EntriesService>();
			ValidateButton();
			ValidateInput();
			_button.clicked += AddEntry;
			_input.RegisterValueChangedCallback(CheckButtonInteractable);
			CheckButtonInteractable();
		}

		private void OnDestroy()
        {
            if(_button != null)
			{
                _button.clicked -= AddEntry;
            }

			if(_input != null)
			{
				_input.UnregisterValueChangedCallback(CheckButtonInteractable);
			}
		}

		private void ValidateInput()
		{
			if (_input == null)
			{
				throw new ArgumentException();
			}
		}

		private void ValidateButton()
		{
			if (_button == null)
			{
				throw new ArgumentException();
			}
		}

		private void CheckButtonInteractable()
		{
			_button.SetEnabled(!string.IsNullOrEmpty(_input.value));
		}

		private void CheckButtonInteractable(ChangeEvent<string> evt)
		{
			CheckButtonInteractable();
		}

		private void AddEntry()
		{
			_entriesService.Add(_input.value);
			_input.value = string.Empty;
		}
	}
}
