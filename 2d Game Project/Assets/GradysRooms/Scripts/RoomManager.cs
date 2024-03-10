using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "RoomManager", menuName = "RoomManager")]
public class RoomManager : ScriptableObject
{
    public Vector2 currentRoom;
    public MazeData mazeData;
    public string[] Rooms;
    public string lastDoor = "";

    string ParseName(string str) 
    {
        // parse the string so letters can come in any order of room type
        string parsedRoomName = "";
        str = str.ToLower();

        if (str.IndexOf('u') != -1) {
            parsedRoomName += 'u';
        }
        if (str.IndexOf('d') != -1) {
            parsedRoomName += 'd';
        }
        if (str.IndexOf('l') != -1) {
            parsedRoomName += 'l';
        }
        if (str.IndexOf('r') != -1) {
            parsedRoomName += 'r';
        }

        return parsedRoomName;
    }

    public void StartMaze()
    {
        LoadRoom(ParseName(mazeData.Data[(int)currentRoom.y, (int)currentRoom.x]));
    }

    public void LoadRoom(string parsedRoomName)
    {
        if (parsedRoomName == "u") {
            SceneManager.LoadScene(Rooms[0]);
        }
        else if (parsedRoomName == "d") {
            SceneManager.LoadScene(Rooms[1]);
        }
        else if (parsedRoomName == "l") {
            SceneManager.LoadScene(Rooms[2]);
        }
        else if (parsedRoomName == "r") {
            SceneManager.LoadScene(Rooms[3]);
        }
        else if (parsedRoomName == "ud") {
            SceneManager.LoadScene(Rooms[4]);
        }
        else if (parsedRoomName == "ul") {
            SceneManager.LoadScene(Rooms[5]);
        }
        else if (parsedRoomName == "ur") {
            SceneManager.LoadScene(Rooms[6]);
        }
        else if (parsedRoomName == "dl") {
            SceneManager.LoadScene(Rooms[7]);
        }
        else if (parsedRoomName == "dr") {
            SceneManager.LoadScene(Rooms[8]);
        }
        else if (parsedRoomName == "lr") {
            SceneManager.LoadScene(Rooms[9]);
        }
        else if (parsedRoomName == "udl") {
            SceneManager.LoadScene(Rooms[10]);
        }
        else if (parsedRoomName == "udr") {
            SceneManager.LoadScene(Rooms[11]);
        }
        else if (parsedRoomName == "ulr") {
            SceneManager.LoadScene(Rooms[12]);
        }
        else if (parsedRoomName == "dlr") {
            SceneManager.LoadScene(Rooms[13]);
        }
        else if (parsedRoomName == "udlr") {
            SceneManager.LoadScene(Rooms[14]);
        }
    }

    public void LoadNextRoom(string doorLoc)
    {
        lastDoor = doorLoc;
        string nextRoomType = "";

        // get the next room type
        if (doorLoc == "u") {
            nextRoomType = mazeData.Data[(int)currentRoom.y - 1, (int)currentRoom.x];
            currentRoom.y -= 1;
        }
        else if (doorLoc == "d") {
            nextRoomType = mazeData.Data[(int)currentRoom.y + 1, (int)currentRoom.x];
            currentRoom.y += 1;
        }
        else if (doorLoc == "l") {
            nextRoomType = mazeData.Data[(int)currentRoom.y, (int)currentRoom.x - 1];
            currentRoom.x -= 1;
        }
        else if (doorLoc == "r") {
            Debug.Log(mazeData.Data);
            nextRoomType = mazeData.Data[(int)currentRoom.y, (int)currentRoom.x + 1];
            currentRoom.x += 1;
        }


        // parse the string so letters can come in any order of room type
        string parsedRoomName = ParseName(nextRoomType);

        // load the room
        LoadRoom(parsedRoomName);
    }
}
