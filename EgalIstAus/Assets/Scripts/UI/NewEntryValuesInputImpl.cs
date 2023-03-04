using System;
using UnityEngine;

namespace Application
{
	public class NewEntryValuesInputImpl : MonoBehaviour, NewEntryValuesInput
	{
		[SerializeField]
		private BaseUI _ui;
		[SerializeField]
		private BasicTextInput _nameInput;


		public event Action OnIsValidChanged;
		public bool IsValid => !_nameInput.IsEmpty && !_entriesService.HasEntry(_nameInput.Value);
		public string Name => _nameInput.Value;

		private EntriesService _entriesService;

		private void Awake()
		{
			_ui.Instances.Register<NewEntryValuesInput, NewEntryValuesInputImpl>(this);
			_entriesService = FindObjectOfType<EntriesService>();
		}

		private void Start()
		{
			_nameInput.OnValueChanged += OnNameChanged;
		}

		private void OnDestroy()
		{
			_nameInput.OnValueChanged -= OnNameChanged;
		}

		private void OnNameChanged()
		{
			OnIsValidChanged?.Invoke();
		}
	}
}
