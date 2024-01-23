using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjPools : Singleton<ObjPools>
{

    [SerializeField] private List<Transform> objPools;
    [SerializeField] Transform objHolder;

    protected virtual void LoadHolder()
    {
        if (this.objHolder != null) return;
        this.objHolder = transform.Find("ObjectHolder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void SpawnObjectsInPool(Transform _objTransform)
    { 
        this.objPools.Add(_objTransform);

    }
    public virtual Transform Spawn(Transform prefab, Vector3 spawner)
    {
        Transform goodsObjectTransform = Instantiate(prefab);
        SpawnObjectsInPool(goodsObjectTransform);
        return null;
    }

    protected virtual Transform GetPrefabName(string prefabName)
    {
        foreach(Transform prefab in objPools)
        {
            if (prefab.name == prefabName) return prefab;
        }

        return null;
    }
}
