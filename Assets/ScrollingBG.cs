using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField] RawImage rawImg;
    [SerializeField] float x, y;
    void Update()
    {
        rawImg.uvRect = new Rect(rawImg.uvRect.position + new Vector2(x, y) * Time.deltaTime, rawImg.uvRect.size);
    }
}
