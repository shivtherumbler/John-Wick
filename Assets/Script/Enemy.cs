using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private BoxCollider2D collision2D;
    private Transform targetPlayer;
    private float speed=2f;
    public float distance;
    private Animator animator;
    public float currentYPosition;

    private bool shoot;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        collision2D = GetComponent<BoxCollider2D>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;

        if(Vector2.Distance(transform.position, targetPlayer.position)>= distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);

        }

        if(transform.position.x < targetPlayer.position.x)
        {
            transform.localScale = new Vector3(0.67f, 0.67f, 1);
        }
        else
        {
            transform.localScale = new Vector3(-0.67f, 0.67f, 1);
        }

        if (transform.position.y < currentYPosition)
        {
            currentYPosition = transform.position.y;
            if (transform.localScale.y >= 0.7)
            {
                float i = 0.005f;
                if (transform.localScale.y >= 0.7)
                {
                    i = 0;
                }
                else
                {
                    i = 0.005f;
                }

                transform.localScale = new Vector3(transform.localScale.x + i, transform.localScale.y + i, 1);
            }
        }

        if (transform.position.y > currentYPosition)
        {
            {
                float i = 0.005f;
                if (transform.localScale.y <= 0.5)
                {
                    i = 0;
                }
                else
                {
                    i = 0.005f;
                }

                transform.localScale = new Vector3(transform.localScale.x - i, transform.localScale.y - i, 1);

            }
        }
        

        if (Shoot()==true)
        {
            animator.SetBool("Shoot", true);
            speed = 0.2f;
        }
        else if(Shoot()==false)
        {
            animator.SetBool("Shoot", false);
            speed = 2f;
        }
    }

    private bool Shoot()
    {
        //return rigidBody2D.velocity.y == 0.0f;
        return shoot;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stop")
            shoot = true;

        if (collision.gameObject.tag == "Kill")
        {
                animator.SetBool("Enemy Death", true);
            {
                if (animator.GetBool("Enemy Death") == true)
                {
                    Destroy(gameObject, 1.5f);
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stop")
            shoot = false;

    }

}
