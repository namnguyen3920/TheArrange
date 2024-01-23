using System.Collections.Generic;
using UnityEngine;

public class PathGenerator
{
    private int width;
    private int height;
    private List<Vector2Int> pathCells;
    public PathGenerator(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public List<Vector2Int> PathGenerate()
    {
        pathCells = new List<Vector2Int>();

        int x = 0;
        int y = (int)(height / 2);

        //for (int x = 0; x < width; x++)
        //{
        //    pathCells.Add(new Vector2Int(x, y));
        //}

        while (x < width)
        {
            pathCells.Add(new Vector2Int(x, y));

            bool validMove = false;

            while (!validMove)
            {
                int direction = Random.Range(0, 3);

                // 1: straight
                // 2: left
                // 3: right

                if (direction == 0 || x % 2 == 0 || x > (width - 2))
                {
                    x++;
                    validMove = true;
                }
                else if (direction == 1 && IsFreeMove(x, y + 1) && y < height - 2)
                {
                    y++;
                    validMove = true;
                }
                else if (direction == 2 && IsFreeMove(x, y - 1) && y > 2)
                {
                    y--;
                    validMove = true;
                }
            }
        }
        return pathCells;
    }

    public bool IsFreeMove(int x, int y)
    {
        return !pathCells.Contains(new Vector2Int(x, y));
    }

    public bool IsTakenCell(int x, int y)
    {
        return pathCells.Contains(new Vector2Int(x, y));
    }

    public int getCellNeighbourValue(int x, int y) {
        
        int returnValue = 0;

        if(IsTakenCell(x, y - 1))
        {
            returnValue += 1;
        }

        if(IsTakenCell(x - 1, y))
        {
            returnValue += 2;
        }

        if (IsTakenCell(x + 1, y))
        {
            returnValue += 4;
        }

        if (IsTakenCell(x, y + 1))
        {
            returnValue += 8;
        }

        return returnValue;
    }

}
