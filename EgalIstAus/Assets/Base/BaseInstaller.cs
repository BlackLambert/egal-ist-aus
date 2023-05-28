using SBaier.DI;

namespace Application
{
	public class BaseInstaller : MonoInstaller
	{
		public override void InstallBindings(Binder binder)
		{
			binder.BindInstance(new System.Random());
		}
	}
}
