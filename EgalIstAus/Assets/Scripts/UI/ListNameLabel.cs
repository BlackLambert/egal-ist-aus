using System;
using System.Collections;
using System.Collections.Generic;
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
			SetText();
		}

		private void SetText()
		{
			_label.text = _element.List.Name;
		}
	}
}
