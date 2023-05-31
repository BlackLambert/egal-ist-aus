using SBaier.DI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application
{
	public class EntryView : MonoBehaviour, Injectable
	{
		private Entry _entry;

		public void Inject(Resolver resolver)
		{
			_entry = resolver.Resolve<Entry>();
		}
	}
}
