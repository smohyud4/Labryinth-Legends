using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float move_speed;
    float speed_x, speed_y;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed_x = Input.GetAxisRaw("Horizontal") * move_speed * Time.deltaTime;
        speed_y = Input.GetAxisRaw("Vertical") * move_speed * Time.deltaTime;
        rb.velocity = new Vector2(speed_x, speed_y);
    }
}
