using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using DG.Tweening;

public class GUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Button btn;
    [SerializeField] private Image img;
    [SerializeField] Sprite onPressSprite, defaultSprite;

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.sprite = onPressSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.sprite = defaultSprite;
    }
}
