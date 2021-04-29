using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject Canvas;
    private BoxCollider2D collision2D;

    // Start is called before the first frame update
    void Start()
    {
        collision2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float i = 33;
        if(collision.tag =="Player")
        {
            Canvas.transform.position = new Vector2(transform.position.x - i, transform.position.y);
        }
    }
}
