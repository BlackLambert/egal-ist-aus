using System;
using System.IO;
using UnityEngine;

namespace Application
{
    public abstract class Loader<TData> : MonoBehaviour
    {
		protected abstract string FilePath { get; }

		private DataContainer<TData> container;

		protected virtual void Start()
		{
			container = FindContainer();
			TryLoadData();
		}

		protected abstract DataContainer<TData> FindContainer();

		protected void TryLoadData()
		{
			if (!File.Exists(FilePath))
			{
				container.SetDefault();
				return;
			}

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
