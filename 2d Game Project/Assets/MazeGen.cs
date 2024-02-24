using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    private int[,] maze;
    private List<Vector2> walls;

    void Start()
    {
        GenerateMaze();
        PrintMaze();
    }

    void GenerateMaze()
    {
        maze = new int[height, width];
        walls = new List<Vector2>();

        // Initialize maze with walls
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                maze[y, x] = 1;
            }
        }

        // Start from a random point
        int startX = Random.Range(0, width);
        int startY = Random.Range(0, height);
        maze[startY, startX] = 0;

        AddWalls(startX, startY);

        while (walls.Count > 0)
        {
            // Pick a random wall
            int randomIndex = Random.Range(0, walls.Count);
            Vector2 wall = walls[randomIndex];
            walls.RemoveAt(randomIndex);

            int x = (int)wall.x;
            int y = (int)wall.y;

            // Check if it is linking the maze to a cell containing a wall
            if (x > 1 && maze[y, x - 2] == 1)
            {
                maze[y, x - 1] = maze[y, x - 2] = 0;
                AddWalls(x - 2, y);
            }
            else if (x < width - 2 && maze[y, x + 2] == 1)
            {
                maze[y, x + 1] = maze[y, x + 2] = 0;
                AddWalls(x + 2, y);
            }
            else if (y > 1 && maze[y - 2, x] == 1)
            {
                maze[y - 1, x] = maze[y - 2, x] = 0;
                AddWalls(x, y - 2);
            }
            else if (y < height - 2 && maze[y + 2, x] == 1)
            {
                maze[y + 1, x] = maze[y + 2, x] = 0;
                AddWalls(x, y + 2);
            }
        }
    }

    void AddWalls(int x, int y)
    {
        if (x > 1 && maze[y, x - 2] == 1)
        {
            walls.Add(new Vector2(x - 2, y));
        }
        if (x < width - 2 && maze[y, x + 2] == 1)
        {
            walls.Add(new Vector2(x + 2, y));
        }
        if (y > 1 && maze[y - 2, x] == 1)
        {
            walls.Add(new Vector2(x, y - 2));
        }
        if (y < height - 2 && maze[y + 2, x] == 1)
        {
            walls.Add(new Vector2(x, y + 2));
        }
    }

    void PrintMaze()
    {
        string mazeString = "";
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                mazeString += maze[y, x] == 1 ? " | " : "   ";
            }
            mazeString += "\n";
        }
        Debug.Log(mazeString);
    }
}