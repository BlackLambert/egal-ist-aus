using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application
{
    public class AddEntryButton : BaseButton
	{
		private EntriesService _entriesService;
		private NewEntryValuesInput _valuesInput;

		protected override void Start()
		{
			base.Start();
			_entriesService = FindObjectOfType<EntriesService>();
			_valuesInput = _ui.Instances.Get<NewEntryValuesInput>();
			_valuesInput.OnIsValidChanged += CheckButtonEnabled;
			CheckButtonEnabled();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
		}

		protected override void OnClick()
		{
			_entriesService.Add(_valuesInput.Name);
			CheckButtonEnabled();
		}

		private void CheckButtonEnabled()
		{
			_button.SetEnabled(_valuesInput.IsValid);
		}
	}
}
