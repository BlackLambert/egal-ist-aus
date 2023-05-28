using TMPro;
using UnityEngine;

namespace Application
{
    public abstract class Label : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

		protected virtual void Start()
		{
			UpdateText();
		}

		protected virtual void Reset()
		{
			_text = GetComponent<TextMeshProUGUI>();
		}

		protected void UpdateText()
		{
			_text.text = GetText();
		}

		protected abstract string GetText();
	}
}
