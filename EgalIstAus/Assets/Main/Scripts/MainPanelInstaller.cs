using SBaier.DI;
using UnityEngine;

namespace Application
{
	public class MainPanelInstaller : MonoInstaller
	{
		[SerializeField]
		private MainPanelSwitcher _panelSwitcher;

		public override void InstallBindings(Binder binder)
		{
			binder.BindInstance(_panelSwitcher).WithoutInjection();
		}
	}
}
