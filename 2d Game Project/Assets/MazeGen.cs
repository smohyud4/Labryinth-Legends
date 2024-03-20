using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MazeGenerator : MonoBehaviour
{
    public MazeData md;

    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Cell> Neighbors { get; set; }
        public bool IsVisited { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Neighbors = new List<Cell>();
            IsVisited = false;
        }

        public void AddNeighbor(Cell neighbor)
        {
            Neighbors.Add(neighbor);
        }

        public override string ToString()
        {
            var neighborCoordinates = Neighbors.Select(n => $"({n.X}, {n.Y})");
            return $"Cell at ({X}, {Y}) has neighbors at: {string.Join(", ", neighborCoordinates)}";
        }
    }

    public Cell[,] Grid { get; set; }
    public int Width = 5;
    public int Height = 5;

    public void GenerateMaze()
    {
        // Initialize the grid
        Grid = new Cell[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Grid[x, y] = new Cell(x, y);
            }
        }

        // Add all adjacent cells to the Neighbors list of each cell
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (x > 0) Grid[x, y].AddNeighbor(Grid[x - 1, y]);
                if (x < Width - 1) Grid[x, y].AddNeighbor(Grid[x + 1, y]);
                if (y > 0) Grid[x, y].AddNeighbor(Grid[x, y - 1]);
                if (y < Height - 1) Grid[x, y].AddNeighbor(Grid[x, y + 1]);
            }
        }

        // Start with a random cell
        var start = Grid[UnityEngine.Random.Range(0, Width), UnityEngine.Random.Range(0, Height)];
        start.IsVisited = true;

        // Initialize the list of cells to be processed
        var cellsToProcess = new List<Cell> { start };

        while (cellsToProcess.Count > 0)
        {
            // Pick a random cell from the list
            var currentCell = cellsToProcess[UnityEngine.Random.Range(0, cellsToProcess.Count)];

            // Get the unvisited neighbors of the current cell
            var unvisitedNeighbors = GetUnvisitedNeighbors(currentCell);

            if (unvisitedNeighbors.Count > 0)
            {
                // Pick a random neighbor
                var neighbor = unvisitedNeighbors[UnityEngine.Random.Range(0, unvisitedNeighbors.Count)];

                // Mark the neighbor as visited and add it to the list of cells to be processed
                neighbor.IsVisited = true;
                cellsToProcess.Add(neighbor);
            }
            else
            {
                // If the current cell has no unvisited neighbors, remove it from the list
                cellsToProcess.Remove(currentCell);
            }
        }
    }

    private List<Cell> GetUnvisitedNeighbors(Cell cell)
    {
        return cell.Neighbors.Where(n => !n.IsVisited).ToList();
    }

    public void PrintCellDetails()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Debug.Log(Grid[x, y].ToString());
            }
        }
    }


    public void LoadMaze()
    {
        // the order of the characters in a string does not matter
        // this is just an example of a 3x3 maze
        string[,] data = new string[Width, Height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                var cell = Grid[x, y];
                if (x < Width - 1 && cell.Neighbors.Contains(Grid[x + 1, y]))
                {
                    data[x, y] += "d";
                }
                if (y < Height - 1 && cell.Neighbors.Contains(Grid[x, y + 1]))
                {
                    data[x, y] += "r";
                }
                if (x > 0 && cell.Neighbors.Contains(Grid[x - 1, y]))
                {
                    data[x, y] += "u";
                }
                if (y > 0 && cell.Neighbors.Contains(Grid[x, y - 1]))
                {
                    data[x, y] += "l";
                }
                Debug.Log(Grid[x, y].ToString());
                Debug.Log(data[x, y]);
            }

        }

        md.StartRoom.x = 0;
        md.StartRoom.y = 0;
        md.Data = data;

        md.LoadMaze();
    }

    void Start()
    {
        GenerateMaze();
        LoadMaze();
    }
}