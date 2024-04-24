using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public Animator animator;

    public GameObject graphics;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    private float attack = 5f;
    private float attackSpeed = 5f;
    private float canAttack = 5f;
    private float attackRange = 1.5f;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        animator = graphics.GetComponent<Animator>();
    }

    void UpdatePath(){
        if (seeker.IsDone()){
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p){
        if (!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null){
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        } else {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance){
            currentWaypoint++;
        }

        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        
        float distanceToPlayer = Vector2.Distance(rb.position, target.position);
        if (distanceToPlayer <= attackRange)
        {
            Attack();
            //TODO: TPlayer needs the health script to be useable
            // target.GetComponent<PlayerHealth>().UpdateHealth(-attack);
            
        }
    }

    private void Attack()
    {
        animator.SetFloat("Horizontal", target.position.x - transform.position.x);
        animator.SetFloat("Vertical", target.position.y - transform.position.y);
        animator.SetFloat("Speed", 0);
        rb.velocity = Vector2.zero; // Stop the enemy from moving while attacking
        animator.SetTrigger("Attack");
    }


}
