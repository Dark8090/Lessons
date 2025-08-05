using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Text countText;
    [SerializeField] private GameObject slot;
    [SerializeField] private bool isEmpty = true;

    [SerializeField] private Item item;

    [SerializeField] private Image bufferSprite;





    public void SetSlot(Item newItem, int amount)
    {
        item = newItem;

        if (item != null)
        {
            iconImage.sprite = item.Sprite;
            isEmpty = false;
            item.Amount = amount;

            if (item.ItemData.MaxStackSize > 1)
            {
                
                countText.text = item.Amount.ToString();
                countText.enabled = true;
            }
            else
            {
                countText.enabled = false;
            }

            if (amount <= 1)
            {
                countText.enabled = false;
            }
        }
        else
        {
            isEmpty = true;
        }
    }

    public void ClearSlot()
    {
        item.Amount = 0;
        iconImage.sprite = bufferSprite.sprite;
        countText.text = "";
        item = null;
    }

    public void RemoveItem(int amountToRemove)
    {

        if (item == null || item.Amount <= 0)
        {
            return;
        }

        item.Amount -= amountToRemove;
        if (item.Amount <= 0)
        {
            ClearSlot();
        }
        else
        {
            UpdateCount();
        }

    }
    public void UpdateCount()
    {
        if (item != null && item.ItemData.MaxStackSize > 1)
        {
            countText.text = item.Amount.ToString();
        }
        if (item != null && item.ItemData.MaxStackSize == 0)
        {
            countText.enabled = false;
        }
    }

    public void UpdateAllInfo()
    {
        if (item != null)
        {
            //iconImage.sprite = item.Sprite;
            //if (item.ItemData.MaxStackSize > 1)
            //{
            //    countText.text = item.Amount.ToString();
            //    countText.enabled = true;
            //}
            //else
            //{
            //    countText.enabled = false;
            //}

        }
        else
        {
            ClearSlot();
        }
    }

    public Item GetItem() => item;
    public bool IsEmpty => isEmpty;
}
