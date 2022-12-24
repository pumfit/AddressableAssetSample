using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadRemoteSceneSample : MonoBehaviour
{
    private AsyncOperationHandle loadMapOperation;
    private readonly string remotePath = "";

    private void Start()
    {
        this.LoadRemoteScene();
    }

    public void LoadRemoteScene()
    {
        this.StartCoroutine(this.LoadCatalog(remotePath, "RemoteScene"));
    }

    IEnumerator LoadCatalog(string catalogPath,string sceneKey)
    {
  
        bool isCatalogLoaded = false;
        Addressables.LoadContentCatalogAsync(catalogPath).Completed += (result) =>
        {
             isCatalogLoaded = true;
        };

        while (!isCatalogLoaded)
            yield return null;
    }

    IEnumerator LoadScene(string sceneKey)
    {
        this.loadMapOperation = Addressables.LoadSceneAsync(sceneKey);

        yield return null;

        var percentDone = 0.0f;

        while (!this.loadMapOperation.IsDone)
        {
            percentDone = Mathf.Floor(this.loadMapOperation.PercentComplete * 100.0f);

            Debug.Log($"percentDone : {percentDone} % ");

            yield return null;
        }
    }
}
