using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    PlayerCtrl player;
    Stack<GameObject> pickableObjects = new Stack<GameObject>();

    [SerializeField] LayerMask pickableObject;
    [SerializeField] Transform touchedObjectCheck;

    private PickUpObjects[] pickable;
    public void PickUpbject()
    {
        
    }

    //bool IsTouchedObject()
    //{
    //    return Physics.BoxCast(touchedObjectCheck.position, player.)
    //}
}
