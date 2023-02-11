using UnityEngine;

namespace Application
{
	public class ListsSaver : Saver<ListsData>
	{
		[SerializeField]
		private SaveFileLocation fileLocation;

		protected override string FilePath => fileLocation.FilePath;
		protected override string CombinedPath => fileLocation.CombinedPath;

		protected override IDataContainer<ListsData> FindContainer()
		{
			return FindObjectOfType<ListsService>();
		}
	}
}
