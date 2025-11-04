using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemController : MonoBehaviour
{
   public Item item;

   
    public Button RemoveButton;
    //public TextMeshProUGUI ItemName;
    //public Image ItemIcon;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        InventoryManager.Instance.ListItems();
        Destroy(gameObject);
    }

    //public void setupItem(Item newItem)
    //{
    //    item = newItem;
    //}

    public void AddItem(Item newItem)
    {
        item = newItem;
    }



    //public void UseItem()
    //{
    //    if (item.itemCategory == "Consumable")
    //    {
    //        if (item.itemName == "Health Potion")
    //        {
    //            // restore health
    //            FindObjectOfType<healthSystem>().heal(1);
                
    //            Debug.Log("✅ Health Restored!");
    //        }
    //        else if (item.itemName == "Harmful Potion")
    //        {
    //            FindObjectOfType<healthSystem>().takeDamage(1);

    //            Debug.Log("⚠️ Ouch! Hazard consumed.");
    //        }

    //        InventoryManager.Instance.Remove(item);
    //        InventoryManager.Instance.ListItems();
    //        return;
    //    }

    //    // Book items do nothing here
    //    Debug.Log("📘 Special books cannot be used from bag");
    //}

}
