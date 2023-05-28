using SBaier.DI;
using UnityEngine;

namespace Application
{
	public class ListsLoader : Loader<ListsData>
	{
		private SaveFileLocation fileLocation;

		protected override string FilePath => fileLocation.FilePath;

		public override void Inject(Resolver resolver)
		{
			base.Inject(resolver);
			fileLocation = resolver.Resolve<SaveFileLocation>();
		}
	}
}
