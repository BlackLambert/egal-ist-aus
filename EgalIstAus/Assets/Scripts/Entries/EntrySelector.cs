using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class EntrySelector : BaseButton
	{
        [SerializeField]
        private string _buttonLabelId;
		[SerializeField]
		private string _noEntriesText = "Please add an entry";

		private Label _buttonLabel;
		private EntriesService _entriesService;
		private Entry _formerEntry;

		protected override void Start()
		{
			base.Start();
			_buttonLabel = _ui.Q<Label>(_buttonLabelId);
			_entriesService = FindObjectOfType<EntriesService>();
		}

		private void SelectRandom()
		{
			if(_entriesService.HasEntries())
			{
				SetEntry();
			}
			else
			{
				SetNoEntriesText();
			}
		}

		protected override void OnClick()
		{
			SelectRandom();
		}

		private void SetEntry()
		{
			Entry newEntry = _entriesService.GetRandom(new List<Entry> { _formerEntry });
			_buttonLabel.text = newEntry.Name;
			_formerEntry = newEntry;
		}

		private void SetNoEntriesText()
		{
			_buttonLabel.text = _noEntriesText;
		}
	}
}
