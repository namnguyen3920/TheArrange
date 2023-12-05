using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GridCell", menuName ="TheArrange/GridCell")]

public class GridCell : ScriptableObject
{
    public enum CellType { Path, Ground }

    public CellType cellType;
    public GameObject cellPrefabs;
    public int yRotation;
}
