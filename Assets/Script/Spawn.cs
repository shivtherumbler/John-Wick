using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private BoxCollider2D collision2D;
    public GameObject Wave;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        collision2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Wave.GetComponent<WaveSpawnner>().enabled = true;
            spriteRenderer.enabled = false;

        }
    }
}