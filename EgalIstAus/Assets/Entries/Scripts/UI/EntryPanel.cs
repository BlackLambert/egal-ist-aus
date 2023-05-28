using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application
{
    public class EntryPanel : MonoBehaviour
    {
        [field: SerializeField]
        public EntryPanelType Type { get; private set; } = EntryPanelType.CreateEntry;
        [SerializeField]
        private Transform _base;

        public void Show(bool show)
        {
            _base.gameObject.SetActive(show);
        }
    }
}
