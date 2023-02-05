using System;
using System.IO;
using UnityEngine;

namespace Application
{
    public class EntryLoader : MonoBehaviour
	{
		[SerializeField]
		private SaveFileLocation fileLocation;

		private IDataContainer<EntriesData> container;

		private void Start()
		{
			container = FindObjectOfType<EntriesService>();
			TryLoadData();
		}

		private void TryLoadData()
		{
			if (!File.Exists(fileLocation.FilePath))
				return;
			try
			{
				LoadData();
			}
            catch(Exception exception)
			{
				Debug.LogWarning($"Failed to load entries: {exception}");
			}
		}

		private void LoadData()
		{
			string jsonString = File.ReadAllText(fileLocation.FilePath);
			EntriesData data = JsonUtility.FromJson<EntriesData>(jsonString);
			container.Set(data);
		}
	}
}
