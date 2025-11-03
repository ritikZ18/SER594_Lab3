using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    public void Pickup()
    {

        // Block Book of Life / Dead conflict BEFORE adding
        bool hasBookOfDead = InventoryManager.Instance.Items.Exists(i => i.itemName == "Book of the Dead");
        bool hasBookOfLife = InventoryManager.Instance.Items.Exists(i => i.itemName == "Book of the Life");

        if ((Item.itemName == "Book of the Life" && hasBookOfDead) ||
            (Item.itemName == "Book of the Dead" && hasBookOfLife))
        {
            PopupMessageUI.Instance.ShowMessage("⚠ You must drop your other sacred book first!");
            return;
        }



        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
        
    //        Pickup();
       
    //}

    private void OnMouseDown()
    {
        Pickup();
    }
}
