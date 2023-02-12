using System;
using UnityEngine;

namespace Application
{
	public class NewListValuesInputImpl : MonoBehaviour, NewListValuesInput
	{
		[SerializeField]
		private BaseUI _ui;
		[SerializeField]
		private BasicTextInput _nameInput;


		public event Action OnIsValidChanged;
		public bool IsValid => !_nameInput.IsEmpty && !_listsService.HasList(_nameInput.Value);
		public string Name => _nameInput.Value;

		private ListsService _listsService;

		private void Awake()
		{
			_ui.Instances.Register<NewListValuesInput, NewListValuesInputImpl>(this);
			_listsService = FindObjectOfType<ListsService>();
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
