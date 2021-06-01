using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public bool FlashActive;
    public float FlashLength;
    private float flashCounter;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public GameObject Damage;
    public AudioClip Hurt;
    private AudioSource Injure;
    public int PlayerMaxHealth;
    public int PlayerCurrentHealth=20;
    public AudioClip Death;
    private AudioSource Dying;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        PlayerCurrentHealth = PlayerMaxHealth;
        Injure = gameObject.GetComponent<AudioSource>();
        Dying = gameObject.GetComponent<AudioSource>();


        if (PlayerCurrentHealth <= 0)
        {

            Die();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerCurrentHealth <=0)
        {
            FlashActive = false;
            //gameObject.SetActive(false);
        }

        if (FlashActive)
        {
            if (flashCounter > FlashLength * .66f)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
            }

            else if (flashCounter > FlashLength * .33f)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
            }

            else if (flashCounter > 0f)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);

            }

            else
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
                FlashActive = false;
            }

            flashCounter -= Time.deltaTime;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hurt")
        {


            if (animator.GetBool("Block") == false)
            {

                PlayerCurrentHealth--;
                Damage.GetComponent<SpriteRenderer>().enabled = true;
                Injure.PlayOneShot(Hurt);


                FlashActive = true;
                flashCounter = FlashLength;


                if (PlayerCurrentHealth <= 0)
                {
                    FlashActive = false;
                    Die();

                }

            }


        }
        else
        {
            Damage.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (other.tag == "PowerUp")
        {
            if (PlayerMaxHealth == 20)
            {
                PlayerMaxHealth = 29;
            }
            if(PlayerMaxHealth == 30)
            {
                PlayerMaxHealth = 39;
            }
            if (PlayerMaxHealth == 40)
            {
                PlayerMaxHealth = 49;
            }
            if (PlayerMaxHealth == 50)
            {
                PlayerMaxHealth = 59;
            }


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Forward")
        {
            Debug.Log(PlayerCurrentHealth);
            PlayerCurrentHealth = PlayerMaxHealth;

            if (PlayerMaxHealth == 29)
            {
                PlayerMaxHealth = 30;
            }
            if (PlayerMaxHealth == 39)
            {
                PlayerMaxHealth = 40;
            }
            if (PlayerMaxHealth == 49)
            {
                PlayerMaxHealth = 50;
            }
            if (PlayerMaxHealth == 59)
            {
                PlayerMaxHealth = 60;
            }
        }

    }

void Die()
{
    Debug.Log("Player died!");
        FlashActive = false;
        Dying.PlayOneShot(Death);
    //Die anim
    animator.SetBool("Death", true);


        //Disable the player
        this.enabled = false;

    //Delete after 5 seconds
    Destroy(gameObject, 5f);
        StartCoroutine(NextLevelAfterWait());

    }

    IEnumerator NextLevelAfterWait()
    {
        yield return new WaitForSeconds(8.0f);

        GameOver();
    }

    void GameOver()
    {
        if (SceneManager.GetActiveScene().name == "Main Scene")
        {
            SceneManager.LoadScene("Game Over Scene");
        }
        else if(SceneManager.GetActiveScene().name == "Infinite Scene")
        {
            SceneManager.LoadScene("Arcade Death");
        }

        else if(SceneManager.GetActiveScene().name == "Timer Mode")
        {
            SceneManager.LoadScene("Timer Mode Lose");
            Time.timeScale = 0f;
        }
    }

    void Sprite()
    {
        FlashActive = false;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        
    }

}
