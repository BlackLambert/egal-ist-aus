using UnityEngine;
using TMPro;
using SBaier.DI;
using System;

namespace Application
{
    public class TextStyleApplier : MonoBehaviour, Injectable
    {
        [SerializeField]
        private TextStyleType _type;
        [SerializeField]
        private TextMeshProUGUI _text;

        private TextStyle _style;

		private void Reset()
		{
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void Inject(Resolver resolver)
        {
            _style = resolver.Resolve<TextStyles>().Get(_type);
        }

        private void Start()
		{
            _text.fontSize = _style.FontSize;
            _text.color = _style.Color;
            _text.fontStyle = _style.Styles;
        }
	}
}
