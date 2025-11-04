using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public Toggle EnableRemove;

    public InventoryItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {


        // Check if inventory already has an item from the same category, mostly for the Book of the Dead
        //Item existingCategoryItem = Items.Find(i => i.itemCategory == item.itemCategory);

        //if (existingCategoryItem != null)
        //{
        //    Debug.Log($"⚠️ You already have a {existingCategoryItem.itemCategory} item ({existingCategoryItem.itemName}). Cannot pick up {item.itemName}.");
        //    print($"⚠️ You already have a {existingCategoryItem.itemCategory} item ({existingCategoryItem.itemName}). Cannot pick up {item.itemName}.");
        //    return;
        //}


        // Special rule: Book of Dead & Book of Life cannot coexist
        bool hasBookOfDead = Items.Exists(i => i.itemName == "Book of the Dead");
        bool hasBookOfLife = Items.Exists(i => i.itemName == "Book of the Life");

        if ((item.itemName == "Book of the Dead" && hasBookOfLife) ||
            (item.itemName == "Book of the Life" && hasBookOfDead))
        {
            Debug.Log($"⚠️ You cannot carry both the Book of the Dead and the Book of Life.");
            return;
        }


        if (!Items.Contains(item))
        {
            Items.Add(item);
            ListItems();
        }
        else
        {
            Debug.Log("Item already in inventory");
        }
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);

             var itemName =  obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
             var itemIcon =  obj.transform.Find("ItemIcon").GetComponent<Image>() ;

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            var button = obj.transform.Find("RemoveButton").GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.RemoveAllListeners();

      
            Item itemToRemove = item;
            button.onClick.AddListener(() =>
            {
                InventoryManager.Instance.Remove(itemToRemove);
                InventoryManager.Instance.ListItems();
            });

            button.gameObject.SetActive(EnableRemove.isOn);




            //var itemButton = obj.GetComponent<Button>();
            //itemButton.onClick.RemoveAllListeners();
            //itemButton.onClick.AddListener(() => controller.UseItem());

            var controller = obj.GetComponent<InventoryItemController>();
            controller.AddItem(item);

            // Call UseItem() when clicking item slot
            var slotBtn = obj.GetComponent<Button>();
            slotBtn.onClick.RemoveAllListeners();
            slotBtn.onClick.AddListener(() => controller.UseItem());


            //button.SetActive(EnableRemove.isOn);

            //obj.GetComponent<InventoryItemController>().AddItem(item);

            if (itemName == null) Debug.LogError("❌ ItemName NOT found in prefab");
            if (itemIcon == null) Debug.LogError("❌ ItemIcon NOT found in prefab");
            if (button == null) Debug.LogError("❌ RemoveButton NOT found in prefab");


            //GameObject obj = Instantiate(InventoryItem, ItemContent);
            //var ctrl = obj.GetComponent<InventoryItemController>();

            //ctrl.ItemName.text = item.itemName;
            //ctrl.ItemIcon.sprite = item.icon;
            //ctrl.setupItem(item);

            //ctrl.RemoveButton.gameObject.SetActive(EnableRemove.isOn);
        }

        SetInventoryItems();
    }

    public void EnableItemsRemove()
    {

        if(EnableRemove.isOn)
        {
            Debug.Log("✅ Enable Remove Items");
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("❌ Disable Remove Items");
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
        
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }
}
