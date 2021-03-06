using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private BoxCollider2D collision2D;
    private Transform targetPlayer;
    public float Speed = 3f;
    private Animator animator;
    public float Distance;
    public float CurrentYPosition;
    bool canShoot;
    public int Life;
    public int MaxLife=5;

    private bool shoot;
    public GameObject Projectile;
    public Transform Shooting;
    public float Velocity;
    public float Time = 2f;
    float Timer;
    public WaveSpawnner kills;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        collision2D = GetComponent<BoxCollider2D>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        CurrentYPosition = transform.position.y;
        Life = MaxLife;
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
            transform.localScale = new Vector3(0.9f, 0.9f, 1);
        }
        else
        {
            transform.localScale = new Vector3(-0.9f, 0.9f, 1);
        }

        if (transform.position.y < CurrentYPosition)
        {
            CurrentYPosition = transform.position.y;
            if (transform.localScale.y >= 1)
            {
                float i = 0.005f;
                if (transform.localScale.y >= 1)
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

        if (transform.position.y > CurrentYPosition)
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

        if (Shoot() == true)
        {
            animator.SetBool("Attack", true);
            Speed = 0.2f;
        }
        else if (Shoot() == false)
        {
            animator.SetBool("Attack", false);
            Speed = 3f;
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
            Life = Life-5;
            if (Life <= 0)
            {
                animator.SetBool("Enemy Death", true);
                {
                    if (animator.GetBool("Enemy Death") == true)
                    {
                        Speed = 0;
                        Destroy(gameObject, 1.5f);
                        Physics2D.IgnoreCollision(targetPlayer.GetComponent<BoxCollider2D>(), collision2D, true);
                    }
                }
            }
        }

        if(collision.gameObject.tag == "Bullet")
        {
            Life--;
            if(Life<=0)
            {
                animator.SetBool("Enemy Death", true);
                {
                    if (animator.GetBool("Enemy Death") == true)
                    {
                        Speed = 0;
                        Destroy(gameObject, 1.5f);
                        Physics2D.IgnoreCollision(targetPlayer.GetComponent<BoxCollider2D>(), collision2D, true);
                    }
                }
            }
        }

        if(collision.gameObject.tag == "Back Wall")
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stop")
            shoot = false;

    }
    private void Kill()
    {
        if (animator.GetBool("Attack") == true)
        {
            if (transform.localScale == new Vector3(-transform.localScale.x, transform.localScale.y, 1))
            {
                GameObject bullet = (GameObject)Instantiate(Projectile, Shooting.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-Velocity * gameObject.transform.localScale.x, 0);
                canShoot = false;
            }
            else if (transform.localScale == new Vector3(transform.localScale.x, transform.localScale.y, 1))
            {
                GameObject bullet = (GameObject)Instantiate(Projectile, Shooting.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Velocity * gameObject.transform.localScale.x, 0);
                canShoot = false;
            }
        }

    }

    void Killno()
    {
        kills.Deaths++;
        kills.Points = kills.Points + 25;
    }

    void Win()
    {
        if (SceneManager.GetActiveScene().name == "Main Scene")
        {
            //StartCoroutine(MainScene());
            SceneManager.LoadScene("Win Scene");

        }

        if (SceneManager.GetActiveScene().name == "Timer Mode")
        {
            //StartCoroutine(MainScene());
            SceneManager.LoadScene("Timer Win");

        }
    }

}
