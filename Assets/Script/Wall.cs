using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    float up_Speed;
    float down_Speed;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        up_Speed = 10;
        down_Speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if(transform.position.y <=2.25f)
           m_Rigidbody.velocity = transform.up * up_Speed;

        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if(transform.position.y >= -4.467f)
            m_Rigidbody.velocity = -transform.up * down_Speed;

        }
    }
}
