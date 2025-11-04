using UnityEngine;
using System.Collections.Generic;

public class NPC_QuestGiver : MonoBehaviour
{
    public string bookName = "Book of the Dead"; // You control which one they want

    public void TriggerDialouge()
    {
        bool hasBookDead = InventoryManager.Instance.Items.Exists(i => i.itemName == "Book of the Dead");
        bool hasBookLife = InventoryManager.Instance.Items.Exists(i => i.itemName == "Book of the Life");

        bool playerHasBook = hasBookDead || hasBookLife;

        // Player DOES NOT have book
        //if (!playerHasBook)
        //{
        //    DialogueSystem.Instance.StartDialogue(new List<string>
        //    {
        //        "Greetings, wanderer. Do you carry the sacred book?",
        //        "Player: I do not.",
        //        "Seek it. Only then can destiny unfold."
        //    });
            
        //}


        if (!playerHasBook)
        {
            List<string> lines = new List<string>()
        {
            "Greetings, wanderer. Do you carry the sacred book?",
            "Player: I do not.",
            "Seek it. Only then can destiny unfold."
        };

            DialogueSystem.Instance.StartDialogue(lines);
        }


        //else
        //{
        //    // Player HAS one of the books
        //    DialogueSystem.Instance.StartDialogue(new List<string>
        //    {
        //        "I sense it... you carry the sacred tome.",
        //        "Player: Yes, I found it.",
        //        "Then hand it over, chosen one.",
        //        "Player: It is yours.",
        //        "Your deed will not be forgotten."
        //    },
        //    () =>
        //    {
        //        var item = InventoryManager.Instance.Items.Find(i => i.itemName.Contains("Book"));
        //        InventoryManager.Instance.Remove(item);
        //        InventoryManager.Instance.ListItems();
        //        PopupMessageUI.Instance.ShowMessage("You have given the sacred book.");
        //    });
        //}

        else
        {
            List<string> lines = new List<string>()
        {
            "I sense it... you carry the sacred tome.",
            "Player: Yes, I found it.",
            "Then hand it over, chosen one.",
            "Player: It is yours.",
            "Your deed will not be forgotten."
        };

            DialogueSystem.Instance.StartDialogue(lines, () =>
            {
                var item = InventoryManager.Instance.Items.Find(i => i.itemName.Contains("Book"));
                InventoryManager.Instance.Remove(item);
                InventoryManager.Instance.ListItems();
                PopupMessageUI.Instance.ShowMessage("You have given the sacred book.");
            });
        }
    }
}
