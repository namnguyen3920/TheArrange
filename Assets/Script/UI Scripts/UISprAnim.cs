using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;

public class UISprAnim : MonoBehaviour
{

    private float fadeTime = 1f;
    [SerializeField] private CanvasGroup canvasGroupMenu;
    [SerializeField] private RectTransform rectTransformMenu;
    [SerializeField] private CanvasGroup canvasGroupSetting;
    [SerializeField] private RectTransform rectTransformSetting;

    public void OnClickFadeIn()
    {
        FadeIn(canvasGroupMenu, rectTransformMenu);
        FadeOut(canvasGroupSetting, rectTransformSetting);
    }

    public void OnClickFadeOut()
    {
        FadeOut(canvasGroupMenu, rectTransformMenu);
        FadeIn(canvasGroupSetting, rectTransformSetting);
    }
    private void FadeIn(CanvasGroup canvasGroup, RectTransform rectTransform)
    {
        canvasGroup.alpha = 0f;
        rectTransform.localPosition = new Vector3(0f, -1080f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(1, fadeTime);
    }

    private void FadeOut(CanvasGroup canvasGroup, RectTransform rectTransform)
    {
        canvasGroup.alpha = 1f;
        rectTransform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime);
    }
}
