using UnityEngine;

namespace Application
{
	public class ListsLoader : Loader<ListsData>
	{
		[SerializeField]
		private SaveFileLocation fileLocation;

		protected override string FilePath => fileLocation.FilePath;

		protected override DataContainer<ListsData> FindContainer()
		{
			return FindObjectOfType<ListsService>();
		}
	}
}
