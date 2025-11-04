using UnityEngine;
using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    private Queue<string> dialogueQueue;
    private Action onDialogueFinished;

    public bool isDialogueActive = false;
    public float lineDelay = 1.2f; // time between sentences

    private void Awake()
    {
        Instance = this;
        dialogueQueue = new Queue<string>();
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(List<string> lines, Action onFinish = null)
    {
        dialogueQueue.Clear();
        foreach (var line in lines) dialogueQueue.Enqueue(line);

        onDialogueFinished = onFinish;
        dialoguePanel.SetActive(true);
        isDialogueActive = true;
        playerMovementRevised.dialouge = true;

        StopAllCoroutines();
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        while (dialogueQueue.Count > 0)
        {
            dialogueText.text = dialogueQueue.Dequeue();
            yield return new WaitForSeconds(lineDelay);
        }

        EndDialogue();
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
        playerMovementRevised.dialouge = false;
        onDialogueFinished?.Invoke();
    }
}
