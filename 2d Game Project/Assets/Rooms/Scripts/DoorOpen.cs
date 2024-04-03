using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public string location;
    public RoomManager rm;
    private bool atdoor = false;

    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        atdoor = true;
    }

    private void OnTriggerExit2D(Collider2D col) 
    {
        atdoor = false;
    }


    void Update()
    {
        if (atdoor && Input.GetKey(KeyCode.E)) {
            Debug.Log("Trying to enter another room");
            rm.LoadNextRoom(location);
        }
    }
}
