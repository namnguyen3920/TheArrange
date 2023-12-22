using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConveyor : MonoBehaviour, IGoodsObjectsParent
{
    [SerializeField] Transform spawner;

    private GoodsObject goodsObject;
    public virtual void Interact(PlayerCtrl player)
    {
        Debug.Log("Interact");
    }

    public Transform GetGoodsObjectFollowTransform()
    {
        return spawner;
    }

    public void SetGoodsObject(GoodsObject goodsObj)
    {
        this.goodsObject = goodsObj;
    }

    public GoodsObject GetGoodsObject() { return goodsObject; }

    public void ClearGoodsObject()
    {
        goodsObject = null;
    }

    public bool HasObject()
    {
        return goodsObject != null;
    }
}
