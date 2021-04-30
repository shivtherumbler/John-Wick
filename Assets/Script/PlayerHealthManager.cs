using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public bool FlashActive;
    public float FlashLength;
    private float flashCounter;
    private SpriteRenderer spriteRenderer;
    private int life;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        life = 10;
    }

    // Update is called once per frame
    void Update()
    {
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
            int anime = 0;
            life--;

            FlashActive = true;
            flashCounter = FlashLength;

            if (anime == 0)
            {
                if (life <= 0)
                {
                    animator.SetBool("Die", true);
                    Destroy(this.gameObject, 5);
                    anime++;
                }

            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Forward")
        {
            Debug.Log(life);
            life = 10;
        }
    }
}
