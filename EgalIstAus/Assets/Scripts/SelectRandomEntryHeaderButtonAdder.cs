using System.Collections.Generic;
using UnityEngine;

namespace Application
{
    public class SelectRandomEntryHeaderButtonAdder : HeaderButtonsAdder
	{
		[SerializeField]
		private OpenListOverviewButton _openListOverviewButtonPrefab;
		[SerializeField]
		private OpenEntriesListButton _openEntriesListButtonPrefab;

		protected override List<ElementUI> buttonPrefabs => new List<ElementUI> 
		{
			_openListOverviewButtonPrefab, 
			_openEntriesListButtonPrefab 
		};
	}
}
