using SBaier.DI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Application
{
    public class RandomColorSwitcherOnEntrySelected : MonoBehaviour, Injectable
    {
        [SerializeField]
        private List<Color> _colors = new List<Color> { Color.white };
		[SerializeField]
		private Graphic _graphic;

        private Container<Entry> _entryContainer;
		private System.Random _random;

		public void Inject(Resolver resolver)
		{
			_entryContainer = resolver.Resolve<Container<Entry>>();
			_random = resolver.Resolve<System.Random>();
		}

		private void Start()
		{
			_entryContainer.OnChange += SetRandomColor;
			SetRandomColor();
		}

		private void Reset()
		{
			_graphic = GetComponent<Graphic>();
		}

		private void OnDestroy()
		{
			_entryContainer.OnChange -= SetRandomColor;
		}

		private void SetRandomColor()
		{
			_graphic.color = _colors[_random.Next(_colors.Count)];
		}
	}
}
