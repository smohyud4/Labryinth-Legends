using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PlayerControl : MonoBehaviour
{
    // 192, 216, C82626, 64
     public float Move_speed = 5;
    Vector2 movement;
    Vector2 movementLast;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int CurrentWeaponNo;
    public static bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentWeaponNo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.GameIsPaused) return;

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
            isWalking = true;
        }
        else{
            isWalking = false;
        } 

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Attack();
            FindObjectOfType<AudioManger>().Play("Sword Swing");
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
