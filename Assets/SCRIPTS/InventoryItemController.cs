using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemController : MonoBehaviour
{
   public Item item;

   
    public Button RemoveButton;
    public TextMeshProUGUI ItemName;
    public Image ItemIcon;

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
}
