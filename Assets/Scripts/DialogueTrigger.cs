using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

	private bool canStartDialogue;

	private void Update()
	{
		if(canStartDialogue && Input.GetButtonDown("Interact") && DialogueManager.instance.inDialogue == false)
		{
			TriggerDialogue();
		}
	}

	public void TriggerDialogue()
	{
		DialogueManager.instance.StartDialogue(dialogue);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			canStartDialogue = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			canStartDialogue = false;
		}
	}
}
