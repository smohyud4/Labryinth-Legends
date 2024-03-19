using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Move_speed = 5;
    Vector2 movement;
    Vector2 movementLast;
    public Rigidbody2D rb;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x == 0 && movement.y == 0) {
          animator.SetFloat("Horizontal", movementLast.x);
          animator.SetFloat("Vertical", movementLast.y);
         } 
 
        if (movement.x != 0 || movement.y != 0){
            movementLast.x = movement.x;
            movementLast.y = movement.y;
        } 
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position+movement * Move_speed * Time.fixedDeltaTime);
    }
}
