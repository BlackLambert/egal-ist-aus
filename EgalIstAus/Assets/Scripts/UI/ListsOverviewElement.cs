using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application
{
	public class ListsOverviewElement : ElementUI
	{
		public EntryList List { get; private set; }

		public void Init(EntryList list)
		{
			List = list;
		}

		protected override void Init()
		{
			
		}
	}
}
