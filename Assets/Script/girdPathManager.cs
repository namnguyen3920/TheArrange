using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girdPathManager : MonoBehaviour
{
    private int gridWidth = 16;
    private int gridHeight = 8;
    private int minPathLength = 25;
    private int pathSize;
    [SerializeField] private GameObject title;
    List<Vector2Int> pathCells;
    private PathGenerator pathGenerator;
    
    // Start is called before the first frame update
    void Start()
    {
        pathGenerator = new PathGenerator(gridWidth, gridHeight);
        List<Vector2Int> pathCells = pathGenerator.PathGenerate();
        pathSize = pathCells.Count;
        //BoardSizeManage();
        StartCoroutine(GeneratePath(pathCells));
    }

    private IEnumerator GeneratePath(List<Vector2Int> pathCells)
    {
        foreach(Vector2Int pathCell in pathCells)
        {
            Instantiate(title, new Vector3(pathCell.x, 0f, pathCell.y), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void BoardSizeManage()
    {
        while (pathSize < minPathLength)
        {
            pathCells = pathGenerator.PathGenerate();
            pathSize = pathCells.Count;
        }
    }
}
