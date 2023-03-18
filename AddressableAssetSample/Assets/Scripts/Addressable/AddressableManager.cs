using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.ResourceProviders;

public partial class AddressableManager : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    private  AsyncOperationHandle<SceneInstance> loadMapOperation;

    public async void LoadScene()
    {
        await this.LoadSceneAsyncByUniTask();
    }

    private async UniTask LoadSceneAsyncByUniTask()
    {
        var loadMapOperation = Addressables.LoadSceneAsync(this.sceneName);

        await UniTask.WaitWhile(() => !this.loadMapOperation.IsDone);

        var percentDone = Mathf.FloorToInt(this.loadMapOperation.PercentComplete * 100.0f);

        Debug.Log($"percentDone : {percentDone} % ");

        if (this.loadMapOperation.Status == AsyncOperationStatus.Failed)
        {
            Debug.LogError($"Failed to load scene {this.sceneName}: {this.loadMapOperation.OperationException}");
        }
        else
        {
            Scene loadedScene = SceneManager.GetSceneByPath(this.loadMapOperation.Result.Scene.path);
            SceneManager.SetActiveScene(loadedScene);
        }
    }

    public void SetSceneName(string sceneName)
    {
        this.sceneName = sceneName; 
    }

}
