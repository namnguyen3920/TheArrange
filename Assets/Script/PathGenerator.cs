using System.Collections.Generic;
using UnityEngine;

public class PathGenerator
{
    public int width;
    public int height;
    public List<Vector2Int> pathCells;
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
                int direction = Random.Range(1, 3);

                // 1: straight
                // 2: left
                // 3: right

                if (direction == 1 || x % 2 == 0)
                {
                    x++;
                    validMove = true;
                }
                else if (direction == 2 && !IsFreeMove(x, y + 1) && y < height - 3)
                {
                    y++;
                    validMove = true;
                }
                else if (direction == 3 && !IsFreeMove(x, y - 1) && y < 2)
                {
                    y--;
                    validMove = true;
                }
            }
        }
        return pathCells;
    }

    private bool IsFreeMove(int x, int y)
    {
        return pathCells.Contains(new Vector2Int(x, y));
    }

    public int getCellNeighbourValue(int x, int y) {
        
        int returnValue = 0;

        if(!IsFreeMove(x, y - 1))
        {
            returnValue += 1;
        }

        if(!IsFreeMove(x - 1, y))
        {
            returnValue += 2;
        }

        if (!IsFreeMove(x + 1, y))
        {
            returnValue += 4;
        }

        if (!IsFreeMove(x, y + 1))
        {
            returnValue += 8;
        }

        return returnValue;
    }

}
