using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerWin : MonoBehaviour
{
    private BoxCollider2D collision2D;
    private int collide;

    // Start is called before the first frame update
    void Start()
    {
        collision2D = GetComponent<BoxCollider2D>();
        collide = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            if (collide == 0)
            {
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    SceneManager.LoadScene("Timer Win");
                    collide = 1;
                }
            }
        }
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}

