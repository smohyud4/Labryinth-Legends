using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDebugPlayer : MonoBehaviour
{
    public float speed = 5f;
    Vector2 direction;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
            //rm.LoadNextRoom(location);
        
    }
}
