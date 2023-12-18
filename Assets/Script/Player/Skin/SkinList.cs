using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Skin/Info", fileName ="SkinList")]
public class SkinList : ScriptableObject
{
    public List<Skin> Skins;
}

[Serializable]
public class Skin
{
    [SerializeField] int _id;
    [SerializeField] Sprite _imgSkin;
    [SerializeField] string _nameSkin;
    [SerializeField] SkinStatus _statusSkin;

    public int ID {  get => _id; set => _id = value; }
    public Sprite ImgSkin { get => _imgSkin; set => _imgSkin = value; }
    public string NameSkin { get => _nameSkin; set => _nameSkin = value; }
    public SkinStatus StatusSKin { get => _statusSkin; set => _statusSkin = value; }
}

