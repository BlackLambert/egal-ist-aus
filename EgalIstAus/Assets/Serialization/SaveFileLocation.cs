using System.IO;
using UnityEngine;

namespace Application
{
    [CreateAssetMenu(fileName = "SaveFileLocation", menuName = "ScriptableObjects/SaveFileLocation")]
    public class SaveFileLocation : ScriptableObject
    {
        [SerializeField]
        private string path = "entries";
        [SerializeField]
        private string fileName = "entries";
        [SerializeField]
        private string fileType = "json";

        public string CombinedPath => Path.Join(UnityEngine.Application.persistentDataPath, path);
        public string FilePath => Path.Join(CombinedPath, $"{fileName}.{fileType}");
        public string FileName => fileName;

        public string GetPath(string fileName)
		{
            return Path.Join(CombinedPath, $"{fileName}.{fileType}");
        }
    }
}
