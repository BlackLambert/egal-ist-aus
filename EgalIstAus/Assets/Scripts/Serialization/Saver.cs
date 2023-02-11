using System.IO;
using UnityEngine;

namespace Application
{
    public abstract class Saver<TData> : MonoBehaviour
    {
		protected abstract string FilePath { get; }
		protected abstract string CombinedPath { get; }

		private IDataContainer<TData> container;

		protected virtual void Start()
		{
			container = FindContainer();
			container.OnChange += SaveEntries;
		}

		protected abstract IDataContainer<TData> FindContainer();

		private void OnDestroy()
		{
			container.OnChange -= SaveEntries;
		}

		private void SaveEntries()
		{
			TData data = container.Get();
			string jsonString = JsonUtility.ToJson(data);
			if (!Directory.Exists(CombinedPath))
				Directory.CreateDirectory(CombinedPath);
			if (!File.Exists(FilePath))
				File.Create(FilePath).Close();
			StreamWriter writer = new StreamWriter(FilePath, false);
			writer.Write(jsonString);
			writer.Close();
		}
	}
}
