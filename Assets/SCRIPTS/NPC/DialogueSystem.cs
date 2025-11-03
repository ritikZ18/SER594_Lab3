using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    void Awake()
    {
        Instance = this;
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(string[] lines)
    {
        playerMovementRevised.dialouge = true; // Freeze player
        sentences.Clear();

        foreach (string line in lines)
            sentences.Enqueue(line);

        dialoguePanel.SetActive(true);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        playerMovementRevised.dialouge = false; // Unfreeze player
    }
}
