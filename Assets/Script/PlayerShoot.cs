using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{

			Destroy(this.gameObject);
		}

		if(other.gameObject.tag == "Back Wall")
        {
			Destroy(this.gameObject);
		}

		if (other.gameObject.tag == "Forward")
		{
			Destroy(this.gameObject);
		}

	}
}
