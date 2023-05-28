using SBaier.DI;

namespace Application
{
	public class ListsSaver : Saver<ListsData>
	{
		private SaveFileLocation _fileLocation;
		protected override string FilePath => _fileLocation.FilePath;
		protected override string CombinedPath => _fileLocation.CombinedPath;

		public override void Inject(Resolver resolver)
		{
			base.Inject(resolver);
			_fileLocation = resolver.Resolve<SaveFileLocation>();
		}
	}
}
