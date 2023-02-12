using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public abstract class BaseButton : MonoBehaviour
    {
        [SerializeField]
        protected BaseUI _ui;
        [SerializeField]
        private string _buttonID;

        protected Button _button;

        protected virtual void Start()
        {
            _button = _ui.Q<Button>(_buttonID);
            _button.clicked += OnClick;
        }

        protected virtual void OnDestroy()
        {
            _button.clicked -= OnClick;
        }

        protected virtual void Reset()
		{
            _ui = GetComponent<BaseUI>();
        }

        protected abstract void OnClick();
    }
}
