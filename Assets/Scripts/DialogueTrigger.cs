using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

	private bool canStartDialogue;
	private Transform player;
	private Transform target;
	private Quaternion targetRot;

	private void Update()
	{
		if(canStartDialogue && Input.GetButtonDown("Interact") && DialogueManager.instance.inDialogue == false)
		{
			LookAtPlayer();
			TriggerDialogue();
		}
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 6f);
	}

	public void TriggerDialogue()
	{
		DialogueManager.instance.StartDialogue(dialogue);
	}

	void LookAtPlayer()
	{
		targetRot = Quaternion.LookRotation(player.position - transform.position);
		targetRot.x = 0;
		targetRot.z = 0;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			DialogueManager.instance.DisplayInteractDisplay();
			player = other.transform;
			canStartDialogue = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			DialogueManager.instance.HideInteractDisplay();
			canStartDialogue = false;
		}
	}
}
