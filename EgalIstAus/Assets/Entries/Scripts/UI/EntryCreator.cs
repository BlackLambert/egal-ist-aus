using SBaier.DI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Application
{
    public class EntryCreator : MonoBehaviour, Injectable
    {
        [SerializeField]
        private TMP_InputField _nameInput;
		[SerializeField]
		private Button _button;

        private EntriesService _entriesService;

		public void Inject(Resolver resolver)
		{
			_entriesService = resolver.Resolve<EntriesService>();
		}

		private void Start()
		{
			_nameInput.onValueChanged.AddListener(OnTextChange);
			_button.onClick.AddListener(CreateEntry);
			UpdateView();
		}

		private void OnDestroy()
		{
			_nameInput.onValueChanged.RemoveListener(OnTextChange);
			_button.onClick.RemoveListener(CreateEntry);
		}

		private void CreateEntry()
		{
			_entriesService.Add(_nameInput.text);
			ClearInput();
			UpdateView();
		}

		private void ClearInput()
		{
			_nameInput.SetTextWithoutNotify(string.Empty);
		}

		private void OnTextChange(string text)
		{
			UpdateView();
		}

		private void UpdateView()
		{
			bool doesNotExist = !string.IsNullOrEmpty(_nameInput.text) && !_entriesService.HasEntry(_nameInput.text);
			_button.interactable = doesNotExist;
		}
	}
}
