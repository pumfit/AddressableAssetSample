using System.Collections;
using System.Collections.Generic;
using System.IO;
using Addressable;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadAssetSample : MonoBehaviour
{
    private string assetPath;

    [SerializeField]
    private GameObject asset;

    void Start()
    {
        //Notice : AssetDatabase use UnityEditor
        assetPath = AssetDatabase.GetAssetPath(asset);
    }

    public void LoadSelectAsset()
    {
        StartCoroutine(this.LoadAsset());
    }

    private IEnumerator LoadAsset()
    {
        var handle = Addressables.LoadAssetAsync<GameObject>(assetPath);
        yield return handle;
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(handle.Result);
        }
    }
}
