using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	public static DialogueManager instance;

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
	public GameObject continueButton;
	public GameObject interactDisplay;
	public bool inDialogue;
	public Animator animator;
	public Animator fadeAnim;

	private bool transitionScene = false;
	private string sceneName;

    private Queue<string> sentences;
	private FirstPersonController player;
	private Animator interactDisplayAnim;

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
		if (interactDisplay)
		{
			interactDisplayAnim = interactDisplay.GetComponent<Animator>();
		}
	}

	public void StartDialogue(Dialogue dialogue)
	{
		inDialogue = true;
		continueButton.SetActive(true);
		TriggerPlayerFreeze();
		HideInteractDisplay();

		if (dialogue.changeSceneAfterDialogue)
		{
			transitionScene = true;
			sceneName = dialogue.sceneName;
		}
		
		animator.SetBool("IsOpen", true);
		nameText.text = dialogue.name;
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		Debug.Log("Display Next Sentence");
		if(sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(0.01f);
		}
	}

	void EndDialogue()
	{
		Debug.Log("Conversation over");
		inDialogue = false;
		continueButton.SetActive(false);
		TriggerPlayerFreeze();
		animator.SetBool("IsOpen", false);

		if (transitionScene)
		{
			fadeAnim.SetTrigger("FadeOut");
			StartCoroutine(TransitionScene());
		}
	}

	IEnumerator TransitionScene()
	{
		yield return new WaitForSeconds(1.8f);
		SceneManager.LoadScene(sceneName);
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

	public void DisplayInteractDisplay()
	{
		interactDisplayAnim.SetBool("ShowDisplay", true);
	}

	public void HideInteractDisplay()
	{
		interactDisplayAnim.SetBool("ShowDisplay", false);
	}
}
