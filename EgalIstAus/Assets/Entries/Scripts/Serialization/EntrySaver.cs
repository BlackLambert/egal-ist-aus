using SBaier.DI;

namespace Application
{
    public class EntrySaver : Saver<EntriesData>
	{
		protected override string FilePath => _fileLocation.GetPath(FileName);
		protected override string CombinedPath => _fileLocation.CombinedPath;
		private string FileName => $"{_listsService.CurrentListName}_{_fileLocation.FileName}";

		private SaveFileLocation _fileLocation;
		private ListsService _listsService;

		public override void Inject(Resolver resolver)
		{
			base.Inject(resolver);
			_listsService = resolver.Resolve<ListsService>();
			_fileLocation = resolver.Resolve<SaveFileLocation>();
		}
	}
}
