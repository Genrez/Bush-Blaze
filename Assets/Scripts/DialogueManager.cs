using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public static DialogueManager instance;
	public GameObject continueButton;

	public bool inDialogue;

    private Queue<string> sentences;
	private FirstPersonController player;

	private void Awake()
	{
		if(instance != null)
		{
			Destroy(this);
			return;
		}

		instance = this;
	}
	private void Start()
	{
		continueButton.SetActive(false);
		sentences = new Queue<string>();
		player = FindObjectOfType<FirstPersonController>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		inDialogue = true;
		continueButton.SetActive(true);
		TriggerPlayerFreeze();
	
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if(sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		Debug.Log(sentence);
	}

	void EndDialogue()
	{
		inDialogue = false;
		continueButton.SetActive(false);
		TriggerPlayerFreeze();
		Debug.Log("End of conversation");
	}

	public void TriggerPlayerFreeze()
	{
		if (player.playerCanMove == true)
		{
			player.playerCanMove = false;
			player.cameraCanMove = false;
			player.lockCursor = false;
			player.enableHeadBob = false;
		}
		else
		{
			player.playerCanMove = true;
			player.cameraCanMove = true;
			player.lockCursor = true;
			player.enableHeadBob = true;
		}
	}
}
