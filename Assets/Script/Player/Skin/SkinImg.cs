using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkinImg : MonoBehaviour
{

    [SerializeField] Image _imgSkin;
    [SerializeField] Image _hoverButton;
    [SerializeField] Text _titleStatus;

    private Action<Skin> _onClicks;

    [SerializeField] private List<Color> _listcolor;
    private Skin _skinSettings;

    private const string _usedText = "Used";
    private const string _noneText = "";
    public void Init(Skin skinSettings, Action<Skin> onClicks)
    {
        _imgSkin.sprite = skinSettings.ImgSkin;
        _skinSettings = skinSettings;
        SetStatus(skinSettings.StatusSKin);
        _onClicks = onClicks;
    }

    public void OnClick()
    {
        _onClicks(_skinSettings);
    }

    public void SetBackGround (bool choose)
    {
        if (choose)
        {
            _hoverButton.gameObject.SetActive(true);
        }   
        else { _hoverButton.gameObject.SetActive(false); }
    }

    private void SetTextStatus (string value, Color _color)
    {
        _titleStatus.text = value;
        _titleStatus.color = _color;
    }

    public void SetStatus(SkinStatus value)
    {
        _titleStatus.text = _noneText;

        if (value == SkinStatus.None) return;

        if(value == SkinStatus.InUsed)
        {
            SetTextStatus(_usedText, _listcolor[0]);
        }
    }
}
