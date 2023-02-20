using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class ListNameLabel : MonoBehaviour
	{
		[SerializeField]
		private ListsOverviewElement _element;
		[SerializeField]
        private string _labelID;

		private Label _label;

		private void Start()
		{
			_label = _element.Q<Label>(_labelID);
			_element.OnListChanged += SetText;
			SetText();
		}

		private void OnDestroy()
		{
			_element.OnListChanged -= SetText;
		}

		private void SetText()
		{
			_label.text = _element.List.Name;
		}
	}
}
