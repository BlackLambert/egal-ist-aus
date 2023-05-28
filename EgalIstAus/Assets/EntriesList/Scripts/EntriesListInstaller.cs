using SBaier.DI;
using UnityEngine;

namespace Application
{
    public class EntriesListInstaller : MonoInstaller
    {
		[SerializeField]
		private SaveFileLocation fileLocation;

		public override void InstallBindings(Binder binder)
		{
			binder.Bind<DataContainer<ListsData>>().And<ElementsContainer<EntryList>>().And<ListsService>().ToNew<ListsService>().AsSingle();
			binder.BindComponent<ListsSaver>().FromNewComponentOnNewGameObject("ListsSaver", transform).WithArgument(fileLocation).AsNonResolvable();
			binder.BindComponent<ListsLoader>().FromNewComponentOnNewGameObject("ListsLoader", transform).WithArgument(fileLocation).AsNonResolvable();
		}
    }
}
