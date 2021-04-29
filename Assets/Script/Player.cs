using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed = 4.0f;
    //public float Jumpspeed = 4.0f;
    public GameObject Spawn;
    public GameObject Gun;
    public float currentYPosition;


    private Rigidbody2D rigidBody2D;
    private BoxCollider2D collision2D;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private Animator animator;
    //public Sprite jump;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        collision2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;

        Movement();

    }

    private void Movement()
    {

            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            rigidBody2D.velocity = new Vector2(h * Speed, v * Speed);

            if (h < 0)
            {
                spriteRenderer.flipX = true;

                // if (IsGrounded())
                {

                    animator.enabled = true;
                    animator.SetBool("Walk", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("Crouch Walk", false);
                    animator.SetBool("Block", false);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", false);

                    if (animator.GetBool("Rifle Idle") == true)
                    {
                        animator.SetBool("Walk", false);
                        animator.SetBool("Rifle Walk", true);
                        animator.SetBool("Shoot", false);

                }

                }
            }

            else if (h > 0)
            {
                spriteRenderer.flipX = false;

                // if (IsGrounded())
                {

                    animator.enabled = true;
                    animator.SetBool("Walk", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("Crouch Walk", false);
                    animator.SetBool("Block", false);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", false);

                    if (animator.GetBool("Rifle Idle") == true)
                    {
                        animator.SetBool("Walk", false);
                        animator.SetBool("Rifle Walk", true);
                        animator.SetBool("Shoot", false);

                }
                }
            }

            else if (h == 0)
            {

                animator.SetBool("Walk", false);
                animator.SetBool("Run", false);
                animator.SetBool("Crouch", false);
                animator.SetBool("Up", false);
                animator.SetBool("Down", false);
                animator.SetBool("Crouch Walk", false);
                animator.SetBool("Block", false);
                animator.SetBool("Hit", false);
                animator.SetBool("Rifle Walk", false);
                animator.SetBool("Shoot", false);


                //if (IsGrounded())
                //{
                //    animator.SetBool("Jump", false);
                // }

            }

            // if (Input.GetKey(KeyCode.Space) && IsGrounded())
            //{
            /*
                    animator.SetBool("Jump", true);
                    animator.SetBool("Walk", false);
                    animator.SetBool("Crouch", false);

                    //rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, Jumpspeed);

            }*/

            if (Input.GetKey(KeyCode.LeftShift) && h != 0)
            {
                // if (IsGrounded())
                {
                    animator.SetBool("Run", true);
                    animator.SetBool("Walk", false);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", false);
                    animator.SetBool("Crouch Walk", false);
                    //animator.SetBool("Jump", false);
                }
                Speed = 6;

            }
            else
            {
                Speed = 4;
            }

            if (Input.GetKey(KeyCode.C) && h == 0)
            {
                // if (IsGrounded())
                {
                    animator.SetBool("Crouch", true);
                    animator.SetBool("Walk", false);
                    //animator.SetBool("Jump", false);
                }

            }

            if (Input.GetKey(KeyCode.C) && h != 0)
            {
                // if (IsGrounded())
                //{
                animator.SetBool("Crouch Walk", true);
                animator.SetBool("Walk", false);
                animator.SetBool("Crouch", false);

            if(animator.GetBool("Rifle Idle") == true)
            {
                animator.SetBool("Rifle Walk", false);
                
            }
                //animator.SetBool("Jump", false);
                // }
                Speed = 3;
            }

            if (Input.GetKey(KeyCode.S) && h == 0 || Input.GetKey(KeyCode.DownArrow) && h == 0)
            {
                float i = 0.2f;
                // if (IsGrounded())
                {
                    animator.SetBool("Down", true);
                    animator.SetBool("Up", false);
                    animator.SetBool("Block", false);

                if (transform.position.y < currentYPosition)
                {
                    currentYPosition = transform.position.y;
                    if (transform.localScale.y >= 27)
                {
                    i = 0;
                }
                else
                {
                    i = 0.2f;
                }
                if (v != 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x + i, transform.localScale.y + i, 1);
                }
                //animator.SetBool("Jump", false);
                }
                }

            }

            if (Input.GetKey(KeyCode.W) && h == 0 || Input.GetKey(KeyCode.UpArrow) && h == 0)
            {
                float i = 0.2f;
            // if (IsGrounded())
            {
                animator.SetBool("Up", true);
                animator.SetBool("Down", false);
                animator.SetBool("Block", false);

                if (transform.position.y > currentYPosition)
                {
                    currentYPosition = transform.position.y;
                    if (transform.localScale.y <= 20)
                    {
                        i = 0;
                    }
                    else
                    {
                        i = 0.2f;
                    }
                    if (v != 0)
                    {
                        transform.localScale = new Vector3(transform.localScale.x - i, transform.localScale.y - i, 1);
                    }
                    //animator.SetBool("Jump", false);
                }
            }

            }

            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("Hit", true);
                animator.SetBool("Walk", false);

        }

            if (Input.GetKey(KeyCode.B) && h == 0)
            {
                //if (IsGrounded())
                //{
                animator.SetBool("Block", true);
                animator.SetBool("Walk", false);
                //animator.SetBool("Jump", false);
                // }

            }

            if(Input.GetKey(KeyCode.Mouse0) && h==0)
            {
            if (animator.GetBool("Rifle Idle") == true)
            {
                animator.SetBool("Shoot", true);
                
            }
                
            }

        
    }

    /* private bool IsGrounded()
     {
         //return rigidBody2D.velocity.y == 0.0f;
         return isGrounded;
     }

     private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Base")
             isGrounded = true;

     }

     private void OnCollisionExit2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Base")
             isGrounded = false;
     }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        // enable script on GameObject when player enters trigger
        if (other.tag == "Enemy")
        {
            Spawn.GetComponent<WaveSpawnner>().enabled = true;
        }

        if (other.tag == "Gun")
        {

            animator.SetBool("Pickup", true);
            animator.SetBool("Down", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            animator.SetBool("Up", false);
            animator.SetBool("Crouch", false);
            animator.SetBool("Crouch Walk", false);
            animator.SetBool("Hit", false);

        }
        
        if(other.CompareTag("Pillar"))
        {
            spriteRenderer.enabled = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Gun")
        {
           
            Destroy(Gun.gameObject, 0.25f);
            animator.SetBool("Rifle Idle", true);
        }
        animator.SetBool("Pickup", false);

        if (collision.CompareTag("Pillar"))
        {
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // if (collision.gameObject.tag == "Move")
        // isGrounded = true;

    }
}