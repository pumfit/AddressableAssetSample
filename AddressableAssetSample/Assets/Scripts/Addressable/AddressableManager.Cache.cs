using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.ResourceProviders;

public partial class AddressableManager : MonoBehaviour
{

    // 에셋 번들의 종속성 캐시를 삭제합니다.
    private void ClearDependencyCacheAsync(string key)
    {
        
        Addressables.ClearDependencyCacheAsync(key);

    }

    // ClearResourceCacheAsync 모든 어드레서블 에셋에 대한 캐시를 삭제 ...  Unity 2021.1 버전 이상인 경우에만 지원함
    // public async void ClearAllCacheAsync()
    // {
    //     AsyncOperationHandle handle = Addressables.ClearResourceCacheAsync();

    //     await handle.Task;
ㅁ
    //     if (handle.Status == AsyncOperationStatus.Succeeded)
    //     {
    //         Debug.Log("Cache cleared successfully.");
    //     }
    //     else
    //     {
    //         Debug.LogError($"Failed to clear cache: {handle.OperationException}");
    //     }
    // }

    // public void ClearCache()
    // {
    //     https://docs.unity3d.com/ScriptReference/Caching.ClearAllCachedVersions.html
    //     Addressables.ClearAllCachedVersions(sceneName);
    // }

}
