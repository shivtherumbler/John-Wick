using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.gameObject.tag == "Player")
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			
		}
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Player")
		{
			FindObjectOfType<DialogueManager>().EndDialogue();
		}
	}

}
