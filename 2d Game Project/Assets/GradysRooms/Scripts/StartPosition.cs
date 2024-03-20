using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lad : MonoBehaviour
{
    public GameObject player;
    public Transform upDoor, downDoor, leftDoor, rightDoor;
    public RoomManager rm;

    // Start is called before the first frame update
    void Start()
    {
        if (rm.lastDoor == "u") {
            player.transform.position = downDoor.position;
        }
        else if (rm.lastDoor == "d") {
            player.transform.position = upDoor.position;
        }
        else if (rm.lastDoor == "l") {
            player.transform.position = rightDoor.position;
        }
        else if (rm.lastDoor == "r") {
            player.transform.position = leftDoor.position;
        }
    }
}
