using UnityEngine;
using System.IO;

namespace Application
{
    public class EntrySaver : MonoBehaviour
    {
		[SerializeField]
		private SaveFileLocation fileLocation;

		private IDataContainer<EntriesData> container;

		public void Start()
		{
			container = FindObjectOfType<EntriesService>();
			container.OnChange += SaveEntries;
		}

		private void OnDestroy()
		{
			container.OnChange -= SaveEntries;
		}

		private void SaveEntries()
		{
			EntriesData data = container.Get();
			string jsonString = JsonUtility.ToJson(data);
			if (!Directory.Exists(fileLocation.CombinedPath))
				Directory.CreateDirectory(fileLocation.CombinedPath);
			if (!File.Exists(fileLocation.FilePath))
				File.Create(fileLocation.FilePath).Close();
			StreamWriter writer = new StreamWriter(fileLocation.FilePath, false);
			writer.Write(jsonString);
			writer.Close();
		}
	}
}
