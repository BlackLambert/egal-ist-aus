using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class ClearEntriesButton : MonoBehaviour
    {
        [SerializeField]
        private UIDocument _document;
        [SerializeField]
        private string _buttonID;
        [SerializeField]
        private Prompt _promptPrefab;

        private Button _button;
		private EntriesService _entriesService;

		private void Start()
        {
            _button = _document.rootVisualElement.Q<Button>(_buttonID);
            _entriesService = FindObjectOfType<EntriesService>();
            ValidateButton();
            _button.clicked += ClearEntries;
        }

		private void OnDestroy()
        {
            if (_button == null)
            {
                _button.clicked -= ClearEntries;
            }
        }

		private void ValidateButton()
        {
            if (_button == null)
            {
                throw new ArgumentException();
            }
        }

        private void ClearEntries()
        {
            Prompt instance = Instantiate(_promptPrefab);
            instance.Init(_entriesService.Clear, "Willst du wirklich alle Eintäge löschen?");
        }
    }
}
