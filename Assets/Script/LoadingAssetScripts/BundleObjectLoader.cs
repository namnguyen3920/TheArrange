using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;
public class BundleObjectLoader : MonoBehaviour
{
    private enum TypeWanted
    {
        UNKNOWN,
        GAMEOBJECT,
        TEXTURE,
        AUDIOCLIP,
    }

    private void Awake()
    {
        LoadAssetBundle(ActionWantedToAssetBundleLoad);
    }

    private IEnumerator LoadBundleFromServer(Callback<dynamic, TypeWanted> callbackFuntion, string assetBundleName="")
    {
        dynamic assetBundleLoad = null;
        TypeWanted typeReceived = TypeWanted.UNKNOWN;
        string url = "https://drive.google.com/uc?export=download&id=1NWz3lmEPMWICE8NvRFtBO2tM9gxVuGy7/";

        using (UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url))
        {
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogWarning("Error to get request: " + url + " " + www.error);
            }
            else
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
                assetBundleLoad = bundle.LoadAsset(bundle.GetAllAssetNames()[0]);
                bundle.Unload(false);
                yield return new WaitForEndOfFrame();
            }
            www.Dispose();
        }
        Debug.Log("AssetBundle unload is type of: " + assetBundleLoad);
        typeReceived = (TypeWanted)CheckAssetBundleLoadType(assetBundleLoad);
        callbackFuntion(assetBundleLoad, typeReceived);
    }

    private int CheckAssetBundleLoadType(dynamic assetBundleLoad)
    {
        TypeWanted typeWanted = TypeWanted.UNKNOWN;
        //if(assetBundleLoad is GameObject)
        //{
        //    typeWanted = TypeWanted.GAMEOBJECT;
        //}s
        switch (assetBundleLoad)
        {
            case GameObject:
                typeWanted = TypeWanted.GAMEOBJECT;
                break;
            case Texture:
                typeWanted = TypeWanted.TEXTURE;
                break;
            case AudioClip:
                typeWanted = TypeWanted.AUDIOCLIP;
                break;
            default:
                typeWanted = TypeWanted.UNKNOWN;
                break;
        }
        return (int)typeWanted;
    }
    private void LoadAssetBundle (Callback<dynamic, TypeWanted> callbackFunction, string assetBundleName = "")
    {
        StartCoroutine(LoadBundleFromServer(callbackFunction, assetBundleName));
    }
    private void ActionWantedToAssetBundleLoad(dynamic assetDownload, TypeWanted typeWanted)
    {
        switch (typeWanted)
        {
            case TypeWanted.UNKNOWN:
                Debug.Log("This asset is unknown type");
                break;
            case TypeWanted.GAMEOBJECT:
                InstantiateGameObjectFromAssetBundle(assetDownload as GameObject);
                break;
            case TypeWanted.AUDIOCLIP:
                Debug.Log("This asset is audio type");
                break;
            case TypeWanted.TEXTURE:
                Debug.Log("This asset is texture type");
                break;
            default:
                break;
        }
    }
    private void InstantiateGameObjectFromAssetBundle(GameObject go)
    {
        GameObject InstantiateGO = Instantiate(go);
        InstantiateGO.transform.position = Vector3.zero;
    }
}
