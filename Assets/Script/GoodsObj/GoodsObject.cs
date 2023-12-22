using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsObject : MonoBehaviour
{
    [SerializeField] GoodsSO goodsObjectSO;

    private IGoodsObjectsParent goodsObjectsParent;

    public GoodsSO GetGoodsObjectSO ()
    {
        return goodsObjectSO;
    }

    public void SetGoodsObjectParent(IGoodsObjectsParent goodsObjectsParent)
    {
        if (this.goodsObjectsParent != null)
        {
            this.goodsObjectsParent.ClearGoodsObject();
        }

        this.goodsObjectsParent = goodsObjectsParent;        

        if(goodsObjectsParent.HasObject()) 
        {
            Debug.LogError("Already has an object");
        }

        goodsObjectsParent.SetGoodsObject(this);

        transform.parent = goodsObjectsParent.GetGoodsObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IGoodsObjectsParent GetGoodsObjectParent()
    {
        return goodsObjectsParent;
    }
}
