using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen2 : MonoBehaviour
{
    private const int MazeSize = 5;
    private int[,] maze = new int[MazeSize, MazeSize];
    private List<Vector2Int> walls = new List<Vector2Int>();
    public MazeData md;
    private string[,] data = new string[MazeSize, MazeSize];
    void Start()
    {

        // Initialize the maze with all walls (represented by 1)
        for (int i = 0; i < MazeSize; i++)
        {
            for (int j = 0; j < MazeSize; j++)
            {
                maze[i, j] = 1;
            }
        }

        // Start from a random cell
        var startCell = new Vector2Int(Random.Range(0, MazeSize), Random.Range(0, MazeSize));

        md.StartRoom.x = startCell.y;
        md.StartRoom.y = startCell.x;

        Debug.Log($"Start cell: ({startCell.x}, {startCell.y})");


        maze[startCell.x, startCell.y] = 0;

        // Add the neighbors of the start cell to the walls list
        AddWalls(startCell);

        // While there are walls in the list
        while (walls.Count > 0)
        {
            // Pick a random wall from the list
            var randomWall = walls[Random.Range(0, walls.Count)];

            // If only one of the two cells that the wall divides is visited
            if (IsOnlyOneAdjacentCellVisited(randomWall))
            {
                // Make the wall a passage
                maze[randomWall.x, randomWall.y] = 0;

                // Add the unvisited cell to the maze
                AddWalls(randomWall);
            }

            // Remove the wall from the list
            walls.Remove(randomWall);
        }

        for (int i = 0; i < MazeSize; i++)
        {
            for (int j = 0; j < MazeSize; j++)
            {
                if (maze[i, j] == 0) // If the cell is a passage
                {
                    var directions = new List<Vector2Int>
                    {
                        Vector2Int.up,
                        Vector2Int.down,
                        Vector2Int.left,
                        Vector2Int.right
                    };

                    foreach (var direction in directions)
                    {
                        var neighbor = new Vector2Int(i, j) + direction;

                        if (neighbor.x >= 0 && neighbor.x < MazeSize && neighbor.y >= 0 && neighbor.y < MazeSize && maze[neighbor.x, neighbor.y] == 0)
                        {
                            if (direction == Vector2Int.up)
                            {
                                data[i, j] += "r";
                            }
                            else if (direction == Vector2Int.down)
                            {
                                data[i, j] += "l";
                            }
                            else if (direction == Vector2Int.left)
                            {
                                data[i, j] += "u";
                            }
                            else if (direction == Vector2Int.right)
                            {
                                data[i, j] += "d";
                            }
                        }
                    }

                    Debug.Log($"Cell ({i}, {j}): {data[i, j]}");
                }
            }
        }

        md.Data = data;
        md.LoadMaze();

        PrintAccessibleNeighbors();
    }

    void AddWalls(Vector2Int cell)
    {
        var directions = new List<Vector2Int>
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };

        foreach (var direction in directions)
        {
            var adjacentCell = cell + direction;

            if (adjacentCell.x >= 0 && adjacentCell.x < MazeSize && adjacentCell.y >= 0 && adjacentCell.y < MazeSize && maze[adjacentCell.x, adjacentCell.y] == 1)
            {
                walls.Add(adjacentCell);
            }
        }
    }

    bool IsOnlyOneAdjacentCellVisited(Vector2Int cell)
    {
        var directions = new List<Vector2Int>
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };

        int visitedCount = 0;

        foreach (var direction in directions)
        {
            var adjacentCell = cell + direction;

            if (adjacentCell.x >= 0 && adjacentCell.x < MazeSize && adjacentCell.y >= 0 && adjacentCell.y < MazeSize && maze[adjacentCell.x, adjacentCell.y] == 0)
            {
                visitedCount++;
            }
        }

        return visitedCount == 1;
    }

    void PrintAccessibleNeighbors()
    {
        var directions = new List<Vector2Int>
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

        for (int i = 0; i < MazeSize; i++)
        {
            for (int j = 0; j < MazeSize; j++)
            {
                if (maze[i, j] == 0) // If the cell is a passage
                {
                    Debug.Log($"Cell ({i}, {j}) can go to:");

                    foreach (var direction in directions)
                    {
                        var neighbor = new Vector2Int(i, j) + direction;

                        if (neighbor.x >= 0 && neighbor.x < MazeSize && neighbor.y >= 0 && neighbor.y < MazeSize && maze[neighbor.x, neighbor.y] == 0)
                        {
                            Debug.Log($"({neighbor.x}, {neighbor.y})");
                        }
                    }
                }
            }
        }
    }
}