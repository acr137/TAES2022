using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public Text nameText;
    public Text dialogueText;
    
    private Queue<string> sentences = new Queue<string>();
    public Dialogue dialogue;
   
    
    void Start()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with" + dialogue.name);
        animator.SetBool("IsOpen",true);
        sentences.Clear();
        Time.timeScale = 0.1f;

        foreach (string sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Debug.Log("Sentences left: " + sentences.Count);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.text = sentence;

    }
   
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Time.timeScale = 1f;
        Debug.Log("End of conversation");
    }
}
