using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsBasket : MonoBehaviour, IGoodsObjectsParent
{
    [SerializeField] GoodsSO goodsObjectSO;
    [SerializeField] Transform spawner;

    private GoodsObject goodsObject;

    public virtual void Interact(PlayerCtrl player)
    {
        Debug.Log("Interact");
        if (goodsObject == null)
        {
            Transform goodsObjectTransform = Instantiate(goodsObjectSO.prefab, spawner);
            //Transform goodsObjectTransform = goodsObjectSO.prefab.transform;
            goodsObjectTransform.GetComponent<GoodsObject>().SetGoodsObjectParent(this);
            //goodsObject = goodsObjectTransform.GetComponent<GoodsObject>();
            //goodsObject.SetGoodsObjectParent(this);

        }
        else
        {
            goodsObject.SetGoodsObjectParent(player);
        }
        //Debug.Log(goodsObjectTransform.GetComponent<GoodsObject>().GetGoodsObject().objName);
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
