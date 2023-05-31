using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Application
{
    public class InteractableSwitcher : MonoBehaviour
    {
        [SerializeField]
        private Selectable _selectable;

        private Dictionary<object, bool> objectToAllowInteract = new Dictionary<object, bool>();

		private void Start()
		{
			UpdateInteractableState();
		}

		private void Reset()
		{
			_selectable = GetComponent<Selectable>();
		}

		public void SetInteracable(object requester, bool allowInteract)
		{
			objectToAllowInteract[requester] = allowInteract;
			UpdateInteractableState();
		}

		public void Unregister(object requester)
		{
			if(!objectToAllowInteract.ContainsKey(requester))
			{
				throw new ArgumentException();
			}
			objectToAllowInteract.Remove(requester);
		}

		private void UpdateInteractableState()
		{
			_selectable.interactable = objectToAllowInteract.Values.All(allowInteract => allowInteract == true);
		}
	}
}
