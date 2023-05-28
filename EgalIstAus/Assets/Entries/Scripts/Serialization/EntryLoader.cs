using SBaier.DI;

namespace Application
{
    public class EntryLoader : Loader<EntriesData>
	{
		private SaveFileLocation fileLocation;

		protected override string FilePath => fileLocation.GetPath(fileName);

		private string fileName => $"{listsService.CurrentListName}_{fileLocation.FileName}";
		private ListsService listsService;

		public override void Inject(Resolver resolver)
		{
			base.Inject(resolver);
			fileLocation = resolver.Resolve<SaveFileLocation>();
			listsService = resolver.Resolve<ListsService>();
		}

		protected override void Start()
		{
			listsService.OnCurrentChange += TryLoadData;
			base.Start();
		}

		protected void OnDestroy()
		{
			listsService.OnCurrentChange -= TryLoadData;
		}
	}
}
