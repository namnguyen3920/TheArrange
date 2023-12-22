using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsBasket : BaseConveyor
{
    [SerializeField] GoodsSO goodsObjectSO;

    public override void Interact(PlayerCtrl player)
    {
        if (!HasObject())
        {
            Transform goodsObjectTransform = Instantiate(goodsObjectSO.prefab);
            goodsObjectTransform.GetComponent<GoodsObject>().SetGoodsObjectParent(player);
        }
    }
    
}
