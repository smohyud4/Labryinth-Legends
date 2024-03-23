using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    public Transform player;
    public float speed;
    private Vector3 directionToPlayer;
    private Vector3 localScale;
    public float x;
    public float y;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 3f;
        localScale = transform.localScale;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy(){
        directionToPlayer = player.position - transform.position;
        if (Vector3.Distance(player.position, transform.position) > 1.0f){
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        if (directionToPlayer.x > 0){
            localScale.x = -1;
        } else if (directionToPlayer.x < 0){
            localScale.x = 1;
        }
        transform.localScale = localScale;
    
        animator.SetFloat("Horizontal", transform.position.x);
        animator.SetFloat("Vertical", transform.position.y);
        animator.SetFloat("Speed", transform.position.sqrMagnitude);


        // if(Input.GetKeyDown(KeyCode.Space)){
        //     Attack();
        // }
    }
}
