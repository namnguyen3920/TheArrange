using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] SkinImg skinImg;
    [SerializeField] SkinList _skinSO;
    [SerializeField] private Transform _skinHolderContent;
    [SerializeField] Dictionary<int, SkinImg> _skinDict;

    [SerializeField] private List<Skin> _skinSettings;
    private Skin _skinUse;
    private int idChose = -1;

    private void Start()
    {
        _skinSettings = _skinSO.Skins;
        SpawnSkinImg();
    }
    private void SpawnSkinImg()
    {
        _skinDict = new Dictionary<int, SkinImg>();
        if (_skinSettings.Count < 0) return;
        for (int i = 0; i < _skinSettings.Count; i++)
        {
            SkinImg skin = Instantiate(skinImg, _skinHolderContent);
            _skinDict.Add(_skinSettings[i].ID, skin);
            skin.Init(_skinSettings[i], ProcessEquip);
            SetBGWhenStart(_skinSettings[i]);
            if (_skinSettings[i].StatusSKin == SkinStatus.InUsed)
            {
                _skinUse = _skinSettings[i];
            }
        }
        //_primarypanel.SetHanldeSizeScrollbar();
    }

    private void SetBGWhenStart (Skin skin)
    {
        if(skin.ID == 1)
        {
            ProcessEquip(skin);
        }
        else
        {
            _skinDict[skin.ID].SetBackGround(false);
        }
    }

    public void ProcessEquip (Skin skin)
    {
        if(idChose != -1)
        {
            _skinDict[idChose].SetBackGround(false);
        }
        idChose = skin.ID;
        _skinDict[idChose].SetBackGround(true);
    }

    private void ProcessUsed(Skin skin)
    {
        _skinDict[skin.ID].Init(skin, ProcessEquip);
        if(skin.StatusSKin == SkinStatus.InUsed)
        {
            if(_skinUse == null)
            {
                _skinUse= skin;
            }
            else
            {
                _skinDict[_skinUse.ID].SetStatus(SkinStatus.None);
                _skinUse.StatusSKin = SkinStatus.None;
                _skinUse = skin;
            }
        }
        if(skin.StatusSKin == SkinStatus.None && skin == _skinUse)
        {
            _skinUse = null;
        }
    }
}
