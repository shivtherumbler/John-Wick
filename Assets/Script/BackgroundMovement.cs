using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject Camera;
    public GameObject HealthBar;
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
        int i = 25;

        if (collision.tag == "Player")
        {
            if (collide == 0)
            {
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    Camera.transform.position = new Vector3(Camera.transform.position.x + i, Camera.transform.position.y, Camera.transform.position.z);
                    HealthBar.transform.position = new Vector3(HealthBar.transform.position.x + i, HealthBar.transform.position.y, HealthBar.transform.position.z);
                    collide = 1;
                }
            }
            if (collide == 1)
            {
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
                {
                    Camera.transform.position = new Vector3(Camera.transform.position.x - i, Camera.transform.position.y, Camera.transform.position.z);
                    HealthBar.transform.position = new Vector3(HealthBar.transform.position.x - i, HealthBar.transform.position.y, HealthBar.transform.position.z);
                    collide = 0;
                }
            }
        }
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

}


