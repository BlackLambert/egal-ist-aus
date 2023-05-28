using SBaier.DI;
using UnityEngine;

namespace Application
{
	public class EntriesInstaller : MonoInstaller
	{
		[SerializeField]
		private SaveFileLocation fileLocation;

		public override void InstallBindings(Binder binder)
		{
			binder.Bind<DataContainer<EntriesData>>().And<ElementsContainer<Entry>>().And<EntriesService>().ToNew<EntriesService>().AsSingle();
			binder.BindComponent<EntrySaver>().FromNewComponentOnNewGameObject("EntriesSaver", transform).WithArgument(fileLocation).AsNonResolvable();
			binder.BindComponent<EntryLoader>().FromNewComponentOnNewGameObject("EntriesLoader", transform).WithArgument(fileLocation).AsNonResolvable();
			binder.BindToNewSelf<Container<Entry>>().AsSingle();
		}
	}
}
