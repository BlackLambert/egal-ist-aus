using SBaier.DI;
using UnityEngine;

namespace Application
{
    public class EntryPanelInstaller : MonoInstaller
    {
		[SerializeField]
		private EntryPanelSwitcher _entryPanelSwitcher;

		public override void InstallBindings(Binder binder)
		{
			binder.BindInstance(_entryPanelSwitcher).WithoutInjection();
		}
    }
}
