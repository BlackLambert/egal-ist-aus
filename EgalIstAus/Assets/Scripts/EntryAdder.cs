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
			_input.RegisterCallback<NavigationSubmitEvent>(OnSubmit);
			CheckButtonInteractable();
		}

		private void OnDestroy()
        {
            _button.clicked -= AddEntry;
			_input.UnregisterValueChangedCallback(CheckButtonInteractable);
			_input.UnregisterCallback<NavigationSubmitEvent>(OnSubmit);
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
			if (!string.IsNullOrEmpty(_input.value))
				_entriesService.Add(_input.value);
			_input.SelectNone();
			_input.value = string.Empty;
		}

		private void OnSubmit(NavigationSubmitEvent evt)
		{
			AddEntry();
		}
	}
}
