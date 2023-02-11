using System;
using System.IO;
using UnityEngine;

namespace Application
{
    public abstract class Loader<TData> : MonoBehaviour
    {
		protected abstract string FilePath { get; }

		private IDataContainer<TData> container;

		protected virtual void Start()
		{
			container = FindContainer();
			TryLoadData();
		}

		protected abstract IDataContainer<TData> FindContainer();

		private void TryLoadData()
		{
			if (!File.Exists(FilePath))
				return;
			try
			{
				LoadData();
			}
			catch (Exception exception)
			{
				Debug.LogWarning($"Failed to load entries: {exception}");
			}
		}

		private void LoadData()
		{
			string jsonString = File.ReadAllText(FilePath);
			TData data = JsonUtility.FromJson<TData>(jsonString);
			container.Set(data);
		}
	}
}
