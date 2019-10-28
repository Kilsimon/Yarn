using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInventory : MonoBehaviour
{
    public int ItemSlotsAvailable; //1 indexed
    public float MaxItemWeight;
    public List<Sprite> InventorySprites;
    private List<Item> Items; // 0 idexed
    private List<Sprite> ItemsImage; // 0 idexed
    public List<GameObject> ItemSlots; // 0 idexed

    private int itemSlotsUsed; //1 indexed
    private float usedItemWeight;

    //Check if the itemslot is enabled.
    //Do something when key is pressed.
    //Lets the user stack items of same count.
    //Add/Remove item.

    private void UpdateImageDisplayed()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            InventorySprites = ItemsImage;
        }
    }

    private bool CheckIfItemIsAlreadyInBag(Item itemToCheck)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].ID == itemToCheck.ID)
            {
                //Already in bag
                return true;
            }
        }
        return false;
    }

    private void UpdateItemSlot()
    {
        for (int i = 0; i < ItemSlotsAvailable; i++)
        {
            //Set enabled
            ItemSlots[i].SetActive(false);
        }
        for (int i = 0; i < Items.Count; i++)
        {
            //Set enabled
            ItemSlots[i].SetActive(true);
        }
    }

    private void EnableItemSlot()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            //Set enabled
            ItemSlots[i].SetActive(true);
        }
    }

    //Not done implementing: Use UpdateItemSlot for now.
    private void DisableItemSlot()
    {
        for (int i = ItemSlotsAvailable-1; i > Items.Count-1; i--)
        {
            //Set enabled
            ItemSlots[i].SetActive(false);
        }
    }

    public void AddItem(Item itemToAdd)
    {
        if (itemSlotsUsed == ItemSlotsAvailable)
        {
            //Pop-up (Too many items)
            Debug.Log("Too many Items");
            return;
        } else if (usedItemWeight == MaxItemWeight)
        {
            // pop-up (Can't carry anymore)
            Debug.Log("Too Much Weight");
            return;
        }
        //Add Item
        //Set Sprite
        //Update private values
        Items.Add(itemToAdd);
        ItemsImage.Add(itemToAdd.UIImage);
        itemSlotsUsed++;
        AddWeight(itemToAdd.Weight);
        UpdateItemSlot();
    }

    private void AddWeight(float add)
    {
        usedItemWeight += add;
    }

    private void RemoveWeight(float add)
    {
        usedItemWeight -= add;
    }

    private void DiscardItem(Item itemToDiscard)
    {

    }

    private void UseAnConsumable()
    {

    }

    private void EquipItem()
    {

    }

    private void DeEquipItem(){

    }

    private void AddHealth(int amount)
    {

    }

    private void AddStamina(int amount)
    {

    }

    private void AddMoral(int amount)
    {

    }

    
}
