using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class EntrySelector : MonoBehaviour
    {
		[SerializeField]
		private UIDocument _document;
		[SerializeField]
        private string _buttonID;
        [SerializeField]
        private string _labelButtonID;

		private Button _button;
		private Button _labelButton;
		private EntriesService _entriesService;
		private Entry _formerEntry;

		private void Start()
		{
			_button = _document.rootVisualElement.Q<Button>(_buttonID);
			_labelButton = _document.rootVisualElement.Q<Button>(_labelButtonID);
			_entriesService = FindObjectOfType<EntriesService>();
			ValidateLabelButtonExists();
			ValidateButtonExists();
			_button.clicked += SelectRandom;
		}

		private void OnDestroy()
		{
			if (_button != null)
			{
				_button.clicked -= SelectRandom;
			}
		}

		private void ValidateLabelButtonExists()
		{
			if (_labelButtonID == null)
			{
				throw new ArgumentException($"Button with ID {_labelButtonID} not found");
			}
		}

		private void ValidateButtonExists()
		{
			if (_button == null)
			{
				throw new ArgumentException($"Button with ID {_buttonID} not found");
			}
		}

		private void SelectRandom()
		{
			if(_entriesService.HasEntries())
			{
				Entry newEntry = _entriesService.GetRandom(new List<Entry> { _formerEntry });
				_labelButton.text = newEntry.Name;
				_formerEntry = newEntry;
			}
		}
	}
}
