using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Application
{
    [CreateAssetMenu(fileName = "TextStyles", menuName = "Settings/UI/TextStyles", order = 1)]
    public class TextStyles : ScriptableObject
    {
        [SerializeField]
        private List<TextStyle> _styles = new List<TextStyle>();

        public TextStyle Get(TextStyleType type)
		{
            return _styles.First(style => style.Type == type);
        }
    }
}
