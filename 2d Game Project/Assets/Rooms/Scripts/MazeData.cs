using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MazeData", menuName = "MazeData")]
public class MazeData : ScriptableObject
{
    // a matrix of strings where each string holds a room type
    // example: Data[0][0] = "dr" => the room has a 
    // door in the 'down' position and 'right' position
    public string[ , ] Data;
    public RoomManager rm;

    // an x-y coord that tells us where the starting place and exit are
    public Vector2 StartRoom, EndRoom;


    // loads the first scene and doors pointing to correct adjacent room types 
    public void LoadMaze() 
    {
        rm.currentRoom = StartRoom;
        rm.StartMaze();
    }


    // creates a prefab maze gen for debugging purposes
    public void CreateGenericMaze()
    {
        
    }


    // prints the maze to the console for debugging
    public void PrintMaze()
    {

    }
}
