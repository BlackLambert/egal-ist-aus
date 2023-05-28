using SBaier.DI;
using System.IO;
using UnityEngine;

namespace Application
{
    public abstract class Saver<TData> : MonoBehaviour, Injectable
    {
		protected abstract string FilePath { get; }
		protected abstract string CombinedPath { get; }

		private DataContainer<TData> _container;

		public virtual void Inject(Resolver resolver)
		{
			_container = resolver.Resolve<DataContainer<TData>>();
		}

		protected virtual void Start()
		{
			_container.OnChange += SaveEntries;
		}

		private void OnDestroy()
		{
			_container.OnChange -= SaveEntries;
		}

		private void SaveEntries()
		{
			TData data = _container.Get();
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
