using UnityEngine;

namespace Application
{
    public class MainPanel : MonoBehaviour
    {
        [field: SerializeField]
        public MainPanelType Type { get; private set; }
        [SerializeField]
        private Transform _base;

        public void Show(bool show)
		{
            _base.gameObject.SetActive(show);
        }
    }
}
