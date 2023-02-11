using UnityEngine;

namespace Application
{
    public class EntrySaver : Saver<EntriesData>
	{
		[SerializeField]
		private SaveFileLocation fileLocation;

		protected override string FilePath => fileLocation.GetPath(fileName);
		protected override string CombinedPath => fileLocation.CombinedPath;

		private string fileName => $"{listsService.CurrentListName}_{fileLocation.FileName}";
		private ListsService listsService;

		protected override void Start()
		{
			listsService = FindObjectOfType<ListsService>();
			base.Start();
		}

		protected override IDataContainer<EntriesData> FindContainer()
		{
			return FindObjectOfType<EntriesService>();
		}
	}
}
