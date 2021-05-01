using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{

			Destroy(this.gameObject,0.05f);
		}

		if (other.gameObject.tag == "Shield")
		{

			Destroy(this.gameObject, 0.05f);
		}

		if (other.gameObject.tag == "Base")
		{
			Destroy(this.gameObject);
		}

		if (other.gameObject.tag == "Forward")
		{
			Destroy(this.gameObject);
		}

	}
}
