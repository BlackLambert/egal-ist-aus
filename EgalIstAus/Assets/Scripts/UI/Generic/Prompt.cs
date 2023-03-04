using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class Prompt : MonoBehaviour
    {
        [SerializeField]
        private UIDocument _document;
        [SerializeField]
        private string _cancelButtonID;
        [SerializeField]
        private string _submitButtonID;
        [SerializeField]
        private string _labelID;

        private Button _cancelButton;
        private Button _submitButton;
        private Label _label;
        private Action _submitAction;

        private void Awake()
        {
            _cancelButton = _document.rootVisualElement.Q<Button>(_cancelButtonID);
            _submitButton = _document.rootVisualElement.Q<Button>(_submitButtonID);
            _label = _document.rootVisualElement.Q<Label>(_labelID);
            ValidateUI();
        }

		private void Start()
        {
            _cancelButton.clicked += Destruct;
        }

		private void OnDestroy()
		{
            _submitButton.clicked -= OnSubmit;
            _cancelButton.clicked -= Destruct;
        }

		public void Init(Action submitAction, string text)
		{
            _submitAction = submitAction;
            _submitButton.clicked += OnSubmit;
            _label.text = text;
        }

        private void ValidateUI()
        {
            if (_cancelButton == null || _submitButton == null || _label == null)
            {
                throw new ArgumentException();
            }
        }

        private void OnSubmit()
		{
            _submitAction.Invoke();
            Destruct();
        }

        private void Destruct()
        {
            Destroy(gameObject);
        }
    }
}
