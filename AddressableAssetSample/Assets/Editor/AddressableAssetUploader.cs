using UnityEngine;
using UnityEditor;

public class AddressableAssetUploader 
{
    [MenuItem("Addressable/Auto Upload")]
    private static void AddressableAutoUpload()
    {
        var settings = AddressableAssetSettingsDefaultObject.Settings;
        Debug.Log("Test");
    }
}
