using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int gridX { get; set; }
        public int gridY { get; set; }
        public List<Cell> Neighbors { get; set; }

        public Cell(int x, int y, int cellSize)
        {
            X = x;
            Y = y;
            gridX = x * cellSize + cellSize / 2;
            gridY = y * cellSize + cellSize / 2;
            Neighbors = new List<Cell>();
        }
    }

    public int width = 10;
    public int height = 10;
    public int cellSize = 5;
    private List<Cell> cells;
    private System.Random rand = new System.Random();

    void Start()
    {
        GenerateMaze();
    }

    void GenerateMaze()
    {
        cells = new List<Cell>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                cells.Add(new Cell(x, y, cellSize));
            }
        }

        foreach (Cell cell in cells)
        {
            if (cell.X > 0)
            {
                cell.Neighbors.Add(cells.Find(c => c.X == cell.X - 1 && c.Y == cell.Y));
            }
            if (cell.X < width - 1)
            {
                cell.Neighbors.Add(cells.Find(c => c.X == cell.X + 1 && c.Y == cell.Y));
            }
            if (cell.Y > 0)
            {
                cell.Neighbors.Add(cells.Find(c => c.X == cell.X && c.Y == cell.Y - 1));
            }
            if (cell.Y < height - 1)
            {
                cell.Neighbors.Add(cells.Find(c => c.X == cell.X && c.Y == cell.Y + 1));
            }
        }

        List<Cell> unvisited = new List<Cell>(cells);
        List<Cell> removed = new List<Cell>();
        Cell current = cells[0];
        unvisited.Remove(current);
        removed.Add(current);

        while (unvisited.Count > 0)
        {
            List<Cell> edges = new List<Cell>();
            foreach (Cell cell in cells.Except(unvisited))
            {
                edges.AddRange(cell.Neighbors.Intersect(unvisited));
            }

            Cell next = edges[rand.Next(edges.Count)];
            Cell neighbor = next.Neighbors.Intersect(cells.Except(unvisited)).First();

            next.Neighbors.Remove(neighbor);
            neighbor.Neighbors.Remove(next);

            unvisited.Remove(next);
            removed.Add(next);
            current = next;
        }



        foreach (Cell cell in cells)
        {
            string neighbors = "";
            string removedCells = "";
            foreach (Cell neighbor in cell.Neighbors)
            {
                neighbors += "(" + neighbor.X + ", " + neighbor.Y + ") ";
            }
            //removed cells
            foreach (Cell removedCell in removed)
            {
                if (cell.X == removedCell.X && cell.Y == removedCell.Y)
                {
                    removedCells += "(" + removedCell.X + ", " + removedCell.Y + ") ";
                }
            }
            print("(" + cell.X + ", " + cell.Y + "): " + neighbors + " Removed: " + removedCells);
        }

    }
}