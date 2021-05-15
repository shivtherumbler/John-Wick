using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip Attack;
    public AudioClip PowerUp;
    public AudioClip Fire;
    private AudioSource Coin;
    private AudioSource Hit;
    private AudioSource Shoot;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Hit = gameObject.GetComponent<AudioSource>();
        Coin = gameObject.GetComponent<AudioSource>();
        Shoot = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "PowerUp")
        {
            Coin.PlayOneShot(PowerUp);
        }
    }

    void Fight()
    {

        Hit.PlayOneShot(Attack);

    }

    void Shooting()
    {
        Shoot.PlayOneShot(Fire);
    }
}
