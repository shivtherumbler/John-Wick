using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private BoxCollider2D collision2D;
    private Transform targetPlayer;
    public float Speed = 3f;
    private Animator animator;
    public float Distance;
    public float CurrentYPosition;

    private bool powerup;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        collision2D = GetComponent<BoxCollider2D>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        CurrentYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;

        if (Vector2.Distance(transform.position, targetPlayer.position) >= Distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, Speed * UnityEngine.Time.deltaTime);

        }

        if (transform.position.x < targetPlayer.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1);
        }

        if (Powerup() == true)
        {
            animator.SetBool("Throw", true);
            Speed = 1f;
        }
        else if (Powerup() == false)
        {
            animator.SetBool("Throw", false);
            Speed = 3f;
        }


    }

    private bool Powerup()
    {
        //return rigidBody2D.velocity.y == 0.0f;
        return powerup;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Stop")
            powerup = true;

        if(collision.gameObject.tag == "Forward")
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Stop")
            powerup = false;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stop")
            animator.SetBool("Walk", true);
            
        if(animator.GetBool("Walk")==true)
        {
            animator.SetBool("Throw", false);
        }
    }
}
