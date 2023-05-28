using UnityEngine;
using UnityEngine.SceneManagement;

namespace Application
{
    public class SceneOnStartLoader : MonoBehaviour
    {
        [SerializeField]
        private string _sceneName;
		[SerializeField]
		private LoadSceneMode _loadMode = LoadSceneMode.Additive;

		private void Start()
		{
			SceneManager.LoadScene(_sceneName, _loadMode);
		}
	}
}
