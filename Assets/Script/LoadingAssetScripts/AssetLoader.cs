using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetLoader : MonoBehaviour
{

    [SerializeField] List<AssetReference> assetReferencesObj;

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private GameObject playerController;

    private void Start()
    {
        Addressables.InitializeAsync().Completed += AssetLoader_Completed;
    }

    private void AssetLoader_Completed(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<UnityEngine.AddressableAssets.ResourceLocators.IResourceLocator> obj)
    {
        foreach(var asset in assetReferencesObj)
        {
            asset.InstantiateAsync().Completed += (go) =>
            {
                Debug.Log("Loaded Asset...");
            };
        }
            
    }
}
