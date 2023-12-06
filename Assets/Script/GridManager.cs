using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int gridWidth = 64;
    [SerializeField] private int gridHeight = 8;
    [SerializeField] private int minPathLength = 25;
    private int pathSize;

    [SerializeField] private GameObject tile;
    public GridCell[] pathCellsObjects;
    public GridCell[] sceneObjects;
    List<Vector2Int> pathCells;
    private PathGenerator pathGenerator;
    
    // Start is called before the first frame update
    void Start()
    {
        pathGenerator = new PathGenerator(gridWidth, gridHeight);
        pathCells = pathGenerator.PathGenerate();
        int pathSize = pathCells.Count;
        BoardSizeManage(pathSize);
        StartCoroutine(GeneratePathInst(pathCells));
        StartCoroutine(GenerateSceneObjects());
    }

    private IEnumerator GeneratePathInst(List<Vector2Int> pathCells)
    {
        foreach (Vector2Int pathCell in pathCells)
        {
            int neighbourValue = pathGenerator.getCellNeighbourValue(pathCell.x, pathCell.y);
            GameObject pathTile = pathCellsObjects[neighbourValue].cellPrefabs;
            GameObject pathTileCell = Instantiate(pathTile, new Vector3(pathCell.x, 0f, pathCell.y), Quaternion.identity);
            pathTileCell.transform.Rotate(0f, pathCellsObjects[neighbourValue].yRotation, 0f, Space.Self);
            yield return new WaitForSeconds(0.25f);
        }
        yield return null;
    }

    private void BoardSizeManage(int pathSize)
    {
        while (pathSize < minPathLength)
        {
            pathCells = pathGenerator.PathGenerate();
            pathSize = pathCells.Count;
        }
    }

    IEnumerator GenerateSceneObjects()
    {
        for(int x = 0; x < gridWidth; x++)
        {
            for(int y = 0; y < gridHeight; y++)
            {
                if(pathGenerator.IsFreeMove(x, y))
                {
                    int randomSceneObjects = Random.Range(0, sceneObjects.Length-1);
                    Instantiate(sceneObjects[randomSceneObjects].cellPrefabs, new Vector3(x, 0f, y), Quaternion.identity);
                    yield return new WaitForSeconds(0.01f);
                }
                
            }
        }
        yield return null;
    }
}
