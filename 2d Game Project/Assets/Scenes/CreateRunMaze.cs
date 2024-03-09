using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRunMaze : MonoBehaviour
{
    public MazeData md;

    // use this to generate the maze, store the result in data, and put the player into maze
    void Start()
    {
        // the order of the characters in a string does not matter
        // this is just an example of a 3x3 maze
        string[,] data = {
            { "r", "lr", "ld" },
            { "", "r", "ul"}
        };

        md.StartRoom.x = 0;
        md.StartRoom.y = 0;
        md.Data = data;

        md.LoadMaze();
    }
}
