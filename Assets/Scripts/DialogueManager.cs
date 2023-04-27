using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public static DialogueManager instance;

    private Queue<string> sentences;


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
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		sentences.Clear();
		
		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
	}

	public void DisplayNextSentence()
	{
		if(sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
	}

	void EndDialogue()
	{

	}
}
