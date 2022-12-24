using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableAssetLoader : MonoBehaviour
{
    private async void LoadAsset<T>(string key)
    {
        var op =  Addressables.LoadAssetAsync<T>(key);
    }
}
