using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MazeGenerator : MonoBehaviour
{
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
    public int Width { get; set; }
    public int Height { get; set; }

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

    void Start()
    {
        Width = 3;
        Height = 3;
        GenerateMaze();
        PrintCellDetails();
    }
}