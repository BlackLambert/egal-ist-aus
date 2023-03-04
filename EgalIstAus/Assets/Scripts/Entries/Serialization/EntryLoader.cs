using UnityEngine;

namespace Application
{
    public class EntryLoader : Loader<EntriesData>
	{
		[SerializeField]
		private SaveFileLocation fileLocation;

		protected override string FilePath => fileLocation.GetPath(fileName);

		private string fileName => $"{listsService.CurrentListName}_{fileLocation.FileName}";
		private ListsService listsService;

		protected override void Start()
		{
			listsService = FindObjectOfType<ListsService>();
			listsService.OnCurrentChange += TryLoadData;
			base.Start();
		}

		protected void OnDestroy()
		{
			listsService.OnCurrentChange -= TryLoadData;
		}

		protected override DataContainer<EntriesData> FindContainer()
		{
			return FindObjectOfType<EntriesService>();
		}
	}
}
