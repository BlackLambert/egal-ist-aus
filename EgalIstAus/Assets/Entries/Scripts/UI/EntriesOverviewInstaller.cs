using SBaier.DI;
using UnityEngine;

namespace Application
{
	public class EntriesOverviewInstaller : MonoInstaller
	{
		[SerializeField]
		private EntryView _entryViewPrefab;

		public override void InstallBindings(Binder binder)
		{
			binder.Bind<Factory<EntryView, Entry>>().ToNew<PrefabFactory<EntryView, Entry>>().WithArgument(_entryViewPrefab);
		}
	}
}
