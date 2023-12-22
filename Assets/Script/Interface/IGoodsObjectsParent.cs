using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGoodsObjectsParent
{
    public Transform GetGoodsObjectFollowTransform();
    public void SetGoodsObject(GoodsObject goodsObj);
    public GoodsObject GetGoodsObject();
    public void ClearGoodsObject();
    public bool HasObject();
}
