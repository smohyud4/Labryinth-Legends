using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerCombat : MonoBehaviour
{
    
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) )
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play an attack animation
        animator.SetTrigger("Attack");
        //detect enemies in range
        //apply damage to enemies

    }
}
