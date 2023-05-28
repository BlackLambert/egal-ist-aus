using SBaier.DI;
using UnityEngine;

namespace Application
{
	public class ListEntriesSelectionInstaller : MonoInstaller
	{
		[SerializeField]
		private ListEntryView _listEntryPrefab;

		public override void InstallBindings(Binder binder)
		{
			binder.Bind<Factory<ListEntryView, EntryList>>().ToNew<PrefabFactory<ListEntryView, EntryList>>().WithArgument(_listEntryPrefab);
		}
	}
}
