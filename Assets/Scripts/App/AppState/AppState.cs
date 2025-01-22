using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace App.AppState
{
    public class AppState : MonoBehaviour
    {
        [SerializeField] private Transform[] _dontDestroyObjects = null;

        private const string AppSceneName = "AppScene";
        private const string LoadingSceneName = "LoadingScene";

        private void Awake()
        {
            foreach (var dontDestroyObject in _dontDestroyObjects)
            {
                if (dontDestroyObject != null)
                {
                    DontDestroyOnLoad(dontDestroyObject.gameObject);
                }
            }
        }

        private async void Start()
        {
            await LoadAppScene();
        }

        private async Task LoadAppScene()
        {
            await OpenLoadingScene();
            await LoadSceneTaskAsync(AppSceneName);
        }

        private async Task OpenLoadingScene()
        {
            await LoadSceneTaskAsync(LoadingSceneName);
        }

        private static Task LoadSceneTaskAsync(string sceneName)
        {
            return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single).ToTask();
        }
    }
}
