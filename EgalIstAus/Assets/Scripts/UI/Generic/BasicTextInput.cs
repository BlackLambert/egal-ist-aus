using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class BasicTextInput : MonoBehaviour
    {
        [SerializeField]
        protected BaseUI _ui;
        [SerializeField]
        private string _textFieldID;

        public event Action OnValueChanged;
        public bool IsEmpty => string.IsNullOrEmpty(_textField.text);
        public string Value => _textField.text;
        private TextField _textField;

        protected virtual void Start()
        {
            _textField = _ui.Q<TextField>(_textFieldID);
            _textField.RegisterValueChangedCallback(OnInputValueChanged);
        }

        protected virtual void OnDestroy()
        {
            _textField.UnregisterValueChangedCallback(OnInputValueChanged);
        }

        protected virtual void Reset()
        {
            _ui = GetComponent<BaseUI>();
        }

        private void OnInputValueChanged(ChangeEvent<string> evt)
		{
            OnValueChanged?.Invoke();
        }
    }
}
