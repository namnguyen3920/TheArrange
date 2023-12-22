using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearConveyor : BaseConveyor
{
    public override void Interact(PlayerCtrl player)
    {
        if (!HasObject())
        {
            if(player.HasObject())
            {
                player.GetGoodsObject().SetGoodsObjectParent(this);
            }
        }
        else
        {
            if (HasObject())
            {

            }
            else
            {
                GetGoodsObject().SetGoodsObjectParent(this);
            }
        }
    }
}
