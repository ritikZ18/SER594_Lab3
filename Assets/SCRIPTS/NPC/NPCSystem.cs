//using UnityEngine;

//public class NPCSystem : MonoBehaviour
//{
//    public bool player_detection = false;

//    string[] dialogueLines = new string[]
//    {
//        "Hey there! Welcome to SER594 – Game Programming class!",
//        "You thought we were just gonna play games?",
//        "Nope — we BUILD them here.",
//        "Debugging? Yeah, that’s 80% of your life now.",
//        "But hey, hell yeah — we make magic with code!",
//        "Let's go create something awesome!"
//    };

//    void Update()
//    {
//        if (player_detection && Input.GetKeyDown(KeyCode.T))
//        {
//            DialogueSystem.Instance.StartDialogue(new System.Collections.Generic.List<string>(dialogueLines));
//        }

//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            DialogueSystem.Instance.DisplayNextLine();
//        }
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            player_detection = true;
//        }
//    }

//    void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            player_detection = false;
//        }
//    }
//}
