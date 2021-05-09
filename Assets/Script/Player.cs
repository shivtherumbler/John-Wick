﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float Speed = 4.0f;
    //public float Jumpspeed = 4.0f;
    public GameObject Camera;
    public GameObject Gun;
    public GameObject Briefcase;
    public GameObject BackWall;
    public GameObject HealthBar;
    public float CurrentYPosition;
    bool canShoot;
    public GameObject Projectile;
    public Transform Shooting;
    public float Velocity;
    public float Time = 1f;
    float Timer;
    

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
        CurrentYPosition = transform.position.y;

        var x = PlayerPrefs.GetFloat("x", -7.4f);
        var y = PlayerPrefs.GetFloat("y", -1.64f);

        Debug.Log(x);
        Debug.Log(y);

        if (x != 0.0f && y != 0.0f)
        {
            transform.position = new Vector3(x, y, transform.position.z);
        }
        if(x<=91f)
        {
            transform.position = new Vector3(-7.4f, -1.64f, transform.position.z);
            Camera.transform.position = new Vector3(0, 0, -10);
            BackWall.transform.position = new Vector3(-14.85f, 0, 1);
            HealthBar.transform.position = new Vector3(-5.33f, 4.22f, 0);

        }
        else if (x>91f && x<=191f)
        {
            Camera.transform.position = new Vector3(100, 0, -10);
            BackWall.transform.position = new Vector3(90f, 0, 1);
            HealthBar.transform.position = new Vector3(94.67f, 4.22f, 0);
        }

        else if (x > 191f && x <= 316f)
        {
            Camera.transform.position = new Vector3(200, 0, -10);
            BackWall.transform.position = new Vector3(190f, 0, 1);
            HealthBar.transform.position = new Vector3(194.67f, 4.22f, 0);
        }

        else if( x>316f && x <=516f)
        {
            Camera.transform.position = new Vector3(325, 0, -10);
            BackWall.transform.position = new Vector3(315, 0, 1);
            HealthBar.transform.position = new Vector3(319.67f, 4.22f, 0);
        }    
        else if(x>516f)
        {
            Camera.transform.position = new Vector3(525, 0, -10);
            BackWall.transform.position = new Vector3(515, 0, 1);
            HealthBar.transform.position = new Vector3(519.67f, 4.22f, 0);
        }
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
                    animator.SetBool("Idle", false);

                    if (animator.GetBool("Rifle Idle") == true)
                    {
                        animator.SetBool("Walk", false);
                        animator.SetBool("Rifle Walk", true);
                        animator.SetBool("Shoot", false);
                        animator.SetBool("Idle", false);
                        animator.SetBool("Briefcase Idle", false);
                        animator.SetBool("Pickup Gun", false);

                }

                if (animator.GetBool("Briefcase Idle") == true)
                {
                    animator.SetBool("Walk", false);
                    animator.SetBool("Briefcase Walk", true);
                    animator.SetBool("Shoot", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Pickup Briefcase", false);

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
                    animator.SetBool("Idle", false);

                if (animator.GetBool("Rifle Idle") == true)
                    {
                        animator.SetBool("Walk", false);
                        animator.SetBool("Rifle Walk", true);
                        animator.SetBool("Shoot", false);
                        animator.SetBool("Idle", false);
                        animator.SetBool("Briefcase Idle", false);
                        animator.SetBool("Pickup Gun", false);

                    }

                if (animator.GetBool("Briefcase Idle") == true)
                {
                    animator.SetBool("Walk", false);
                    animator.SetBool("Briefcase Walk", true);
                    animator.SetBool("Shoot", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Pickup Briefcase", false);

                }
            }
            }

            else if (h == 0)
            {
                animator.SetBool("Idle", true);
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
                animator.SetBool("Briefcase Walk", false);

                if(animator.GetBool("Briefcase Idle")==true)
            {
                animator.SetBool("Idle", false);
            }
                if(animator.GetBool("Rifle Idle")==true)
            {
                animator.SetBool("Briefcase Walk", false);
                animator.SetBool("Idle", false);

            }

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
                    animator.SetBool("Briefcase Walk", false);
                //animator.SetBool("Jump", false);
            }
                Speed = 6;

            }
            else
            {
                Speed = 4;
            }

            if (Input.GetKey(KeyCode.C) && h == 0 && v==0)
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

            if (animator.GetBool("Rifle Idle") == true)
            {
                animator.SetBool("Rifle Walk", false);
                
            }

            if (animator.GetBool("Briefcase Idle") == true)
            {
                animator.SetBool("Briefcase Walk", false);
            }
                //animator.SetBool("Jump", false);
                // }
                Speed = 3;
            }

            if (Input.GetKey(KeyCode.S) && h == 0 || Input.GetKey(KeyCode.DownArrow) && h == 0)
            {
                //float i = 0.01f;
                // if (IsGrounded())
                {
                    animator.SetBool("Down", true);
                    animator.SetBool("Up", false);
                    animator.SetBool("Block", false);

               /* if (transform.position.y < CurrentYPosition)
                {
                    CurrentYPosition = transform.position.y;
                    if (transform.localScale.y >= 0.9)
                {
                    i = 0;
                }
                else
                {
                    i = 0.01f;
                }
                if (v != 0 || v!=0 && h!=0)
                {
                    transform.localScale = new Vector3(transform.localScale.x + i, transform.localScale.y + i, 1);
                }
                //animator.SetBool("Jump", false);
                }*/
                }

            }

            if (Input.GetKey(KeyCode.W) && h == 0 || Input.GetKey(KeyCode.UpArrow) && h == 0)
            {
               // float i = 0.01f;
            // if (IsGrounded())
            {
                animator.SetBool("Up", true);
                animator.SetBool("Down", false);
                animator.SetBool("Block", false);

              /*  if (transform.position.y > CurrentYPosition)
                {
                    CurrentYPosition = transform.position.y;
                    if (transform.localScale.y <= 0.5)
                    {
                        i = 0;
                    }
                    else
                    {
                        i = 0.01f;
                    }
                    if (v != 0 || v!= 0 && h != 0)
                    {
                        transform.localScale = new Vector3(transform.localScale.x - i, transform.localScale.y - i, 1);
                    }
                    //animator.SetBool("Jump", false);
                }*/
            }

            }

            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("Hit", true);
                animator.SetBool("Walk", false);

        }

            if (Input.GetKey(KeyCode.B) && h == 0 && v==0)
            {
            //if (IsGrounded())
            //{
            if (animator.GetBool("Idle") == false)
            {
                animator.SetBool("Block", true);
                animator.SetBool("Walk", false);
            }

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

        if (!canShoot)
        {
            Timer -= UnityEngine.Time.deltaTime;

        }
        if (Timer <= 0)
        {
            canShoot = true;
            Timer = Time;
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

        if (other.tag == "Gun")
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Pickup Gun", true);
            animator.SetBool("Down", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            animator.SetBool("Up", false);
            animator.SetBool("Crouch", false);
            animator.SetBool("Crouch Walk", false);
            animator.SetBool("Hit", false);
            animator.SetBool("Rifle Idle", true);

        }
        if (other.tag == "Briefcase")
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Pickup Briefcase", true);
            animator.SetBool("Down", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            animator.SetBool("Up", false);
            animator.SetBool("Crouch", false);
            animator.SetBool("Crouch Walk", false);
            animator.SetBool("Hit", false);
            animator.SetBool("Briefcase Idle", true);

        }

        if (other.CompareTag("Pillar"))
        {
            spriteRenderer.enabled = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Gun")
        {
           
            Destroy(Gun.gameObject);
            animator.SetBool("Rifle Idle", true);
        }
        animator.SetBool("Pickup Gun", false);

        if (collision.tag == "Briefcase")
        {

            Destroy(Briefcase.gameObject);
            animator.SetBool("Briefcase Idle", true);
        }
        animator.SetBool("Pickup Briefcase", false);

        // if (collision.CompareTag("Pillar"))
        //{
        //     spriteRenderer.enabled = true;
        // }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // if (collision.gameObject.tag == "Move")
        // isGrounded = true;
    }

    private void KillEnemy()
    {
        if (animator.GetBool("Shoot") == true)
        {
            if (spriteRenderer.flipX == true)
            {
                GameObject bullet = (GameObject)Instantiate(Projectile, Shooting.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-Velocity * gameObject.transform.localScale.x, 0);
                canShoot = false;
            }
            else
            {
                GameObject bullet = (GameObject)Instantiate(Projectile, Shooting.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Velocity * gameObject.transform.localScale.x, 0);
                canShoot = false;
            }
        }
    }
}