using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Timeline;

public class enemy_movement : MonoBehaviour
{
    // private Rigidbody2D rb;
    public Animator animator;
    // public Transform player;
    // public float speed;
    // private Vector3 directionToPlayer;
    // private Vector3 localScale;
    // public float x;
    // public float y;
    // public float moveSpeed = 3f;
    private float attack = 5f;
    private float attackSpeed = 5f;
    private float canAttack = 0f;

    // Start is called before the first frame update
    // void Start()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    //     speed = 3f;
    //     localScale = transform.localScale;
    // }
    // Update is called once per frame
    Collider2D collision;
    // private void FixedUpdate()
    // {
    //      x= transform.position.x;
    //     y= transform.position.y;
    //     MoveEnemy();

    // }
    public Transform player; // Reference to the player's transform
    public float chaseRange = 10f; // Maximum distance at which the enemy will chase the player
    public float speed = 3f; // Speed at which the enemy moves
    private void Update(){
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if the player is within the chase range
        if (distanceToPlayer <= chaseRange)
        {
            // Move towards the player
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }

    }

    private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            if(attackSpeed <= canAttack){
                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attack);
                animator.SetFloat("Horizontal", player.position.x - transform.position.x);
                animator.SetFloat("Vertical", player.position.y - transform.position.y);
                animator.SetFloat("Speed", 0);
                Attack();
                canAttack = 0f;
            } else {
                canAttack += Time.deltaTime;
            }
        }
    }       

    // private void MoveEnemy(){
    //     directionToPlayer = player.position - transform.position;
    //     if (Vector3.Distance(player.position, transform.position) > 1.0f){
    //         transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    //     }
    //     else{
    //         animator.SetFloat("Horizontal", x);
    //         animator.SetFloat("Vertical", y);
    //         animator.SetFloat("Speed", 0);
    //     }
    //     if (directionToPlayer.x > 0){
    //         localScale.x = -1;
    //     } else if (directionToPlayer.x < 0){
    //         localScale.x = 1;
    //     }
    //     transform.localScale = localScale;
    
    //     animator.SetFloat("Horizontal", transform.position.x);
    //     animator.SetFloat("Vertical", transform.position.y);
    //     animator.SetFloat("Speed", transform.position.sqrMagnitude);

    // }

    private void Attack(){
        animator.SetTrigger("Attack");
    }
}
