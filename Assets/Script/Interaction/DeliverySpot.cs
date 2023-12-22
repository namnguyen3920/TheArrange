using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySpot : BaseConveyor
{
    public override void Interact(PlayerCtrl player)
    {
        if (!HasObject())
        {
            if (player.HasObject())
            {
                player.GetGoodsObject().SetGoodsObjectParent(this);
            }
        }

        else
        {

        }
    }
}
