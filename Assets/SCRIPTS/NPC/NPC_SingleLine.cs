using UnityEngine;
using System.Collections.Generic;

public class NPC_SingleLine : MonoBehaviour
{
    [TextArea] public string message = "Hello traveler! Stay safe on your journey.";

    public void TriggerDialouge()
    {
        Debug.Log("NPC clicked!");
        print("NPC clicked!");
        DialogueSystem.Instance.StartDialogue(new List<string> { message });

    }
}
