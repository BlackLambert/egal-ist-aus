using SBaier.DI;
using System;
using System.IO;
using UnityEngine;

namespace Application
{
    public abstract class Loader<TData> : MonoBehaviour, Injectable
    {
		protected abstract string FilePath { get; }

		private DataContainer<TData> container;

		public virtual void Inject(Resolver resolver)
		{
			container = resolver.Resolve<DataContainer<TData>>();
		}

		protected virtual void Start()
		{
			TryLoadData();
		}

		protected void TryLoadData()
		{
			if (!File.Exists(FilePath))
			{
				container.SetDefault();
				return;
			}

			try
			{
				TData data = LoadData();
				container.Set(data);
			}
			catch (Exception exception)
			{
				Debug.LogWarning($"Failed to load entries: {exception}");
			}
		}

		private TData LoadData()
		{
			string jsonString = File.ReadAllText(FilePath);
			return JsonUtility.FromJson<TData>(jsonString);
		}
	}
}
