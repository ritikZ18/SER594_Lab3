using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    public bool player_detection = false;

    string[] dialogueLines = new string[]
 {
        "Hey there! Welcome to SER594 – Game Programming class!",
        "You thought we were just gonna play games?",
        "Nope — we BUILD them here.",
        "Debugging? Yeah, that’s 80% of your life now.",
        "But hey, hell yeah — we make magic with code!",
        "Let's go create something awesome!"
 };// NPC dialogue lines

    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.T) && !playerMovementRevised.dialouge)
        {
            DialogueSystem.Instance.StartDialogue(dialogueLines);
            Debug.Log("NPC Dialogue started");
        }

        if (playerMovementRevised.dialouge && Input.GetKeyDown(KeyCode.E))
        {
            DialogueSystem.Instance.DisplayNextSentence();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_detection = true;
            Debug.Log("Player Near NPC");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_detection = false;
            Debug.Log("Player Left");
        }
    }
}
