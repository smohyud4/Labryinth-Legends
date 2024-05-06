using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private GameObject player;
    private SpriteRenderer playerRenderer;
    public Inventory inventory;
    private float clock;
    private float teleport;

    //public AudioSource audioSource;
    //public AudioClip cAttack, cTeleport, cMain;
    private bool playerInRange = false;
    public float teletimer = 3;
    public float atttimer = 3;

    // Start is called before the first frame update
    void Start()
    {
        clock = Time.time + atttimer;
        teleport = Time.time + teletimer;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerRenderer = player.GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = player.transform.position + new Vector3(0, 5, 0);
        if (player.transform.position.y + 2 > transform.position.y) 
        {
            spriteRenderer.sortingOrder = 4;
            playerRenderer.sortingOrder = 3;
        }
        else
        {
            spriteRenderer.sortingOrder = 3;
            playerRenderer.sortingOrder = 4;
        }
    }


    public void AttackSound()
    {
        //audioSource.clip = cAttack;
        //audioSource.Play();
    }

    IEnumerator Teleport()
    {
        animator.SetTrigger("Teleport");

        yield return new WaitForSeconds((float)0.3);
        gameObject.transform.position = player.transform.position + new Vector3(0, 5, 0);
    }


    void FixedUpdate()
    {
        if (playerInRange && clock < Time.time)
        {
            FindObjectOfType<AudioManger>().Play("Boss Swing");
            animator.SetTrigger("Attack");
            if (playerInRange) {
                inventory.health -= 5;
            }
            clock = Time.time + atttimer;
        }
        else if (teleport < Time.time) {

            StartCoroutine(Teleport());
                    //audioSource.clip = cTeleport;
        /*audioSource.Play();*/
            FindObjectOfType<AudioManger>().Play("Teleport"); 
            Debug.Log("teleporting to player");
            teleport = Time.time + teletimer;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player") {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player") {
            playerInRange = false;
        }
    }
}
