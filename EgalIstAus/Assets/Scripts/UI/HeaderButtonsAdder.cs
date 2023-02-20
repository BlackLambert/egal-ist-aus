using System.Collections.Generic;
using UnityEngine;

namespace Application
{
    public abstract class HeaderButtonsAdder : MonoBehaviour
    {
		[SerializeField]
		private BaseUI _ui;

		protected abstract List<ElementUI> buttonPrefabs { get; }

		private HeaderUI _header;
		private List<ElementUI> _buttons = new List<ElementUI>();

		public void Start()
		{
			_header = _ui.Instances.Get<HeaderUI>();
			CreateButtons();
			AddButtons();
		}

		public void OnDestroy()
		{
			RemoveButtons();
		}

		private void CreateButtons()
		{
			foreach (ElementUI prefab in buttonPrefabs)
			{
				ElementUI element = Instantiate(prefab);
				element.Create(_ui.Frame);
				_buttons.Add(element);
			}
		}

		private void AddButtons()
		{
			foreach (ElementUI button in _buttons)
			{
				_header.Add(button);
			}
		}

		private void RemoveButtons()
		{
			foreach (ElementUI button in _buttons)
			{
				_header.Remove(button);
				Destroy(button.gameObject);
			}
		}
	}
}
