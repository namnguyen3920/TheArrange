using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundle()
    {
        string assetBundleDirectory = "Assets/StreamingAssets";
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        try { 
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
    }
}
