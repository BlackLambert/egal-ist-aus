using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Application
{
    [CreateAssetMenu(fileName = "TextStyle", menuName = "Settings/UI/TextStyle", order = 0)]
    public class TextStyle : ScriptableObject
    {
        [field: SerializeField] public TextStyleType Type { get; private set; } = TextStyleType.Body;
        [field: SerializeField] public int FontSize { get; private set; } = 24;
        [field: SerializeField] public Color Color { get; private set; } = Color.black;
        [field: SerializeField] public FontStyles Styles { get; private set; } = FontStyles.Normal;
    }
}
