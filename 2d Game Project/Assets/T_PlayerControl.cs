using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PlayerControl : MonoBehaviour
{

     public float Move_speed = 5;
    Vector2 movement;
    Vector2 movementLast;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int CurrentWeaponNo = 0;
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

        if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }
        
        if(Input.GetKeyDown(KeyCode.C)){
            ChangeWeapon();
        }

        if(CurrentWeaponNo == 1){
            Move_speed = 8;
        }
        if(CurrentWeaponNo == 0){
            Move_speed = 5;
        }
    }

     void ChangeWeapon(){
        if(CurrentWeaponNo == 0){
            CurrentWeaponNo++;
            animator.SetLayerWeight(CurrentWeaponNo-1, 0);
            animator.SetLayerWeight(CurrentWeaponNo, 1);
        }
        else{
            CurrentWeaponNo--;
            animator.SetLayerWeight(CurrentWeaponNo+1, 0);
            animator.SetLayerWeight(CurrentWeaponNo, 1);
        }
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position+movement * Move_speed * Time.fixedDeltaTime);
    }
     void Attack(){
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("We hit " + enemy.name);
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
