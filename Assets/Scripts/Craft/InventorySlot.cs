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

        if (newItem != null)
        {
            iconImage.sprite = newItem.Sprite;
            isEmpty = false;

            if (newItem.ItemData.MaxStackSize > 1)
            {
                newItem.Amount = amount;
                countText.text = newItem.Amount.ToString();
                countText.enabled = true;
            }
            else
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
        iconImage.sprite = bufferSprite.sprite;
        countText.text = null;
        item = null;

    }
    public void UpdateCount()
    {
        if (item != null && item.ItemData.MaxStackSize > 1)
        {
            countText.text = item.Amount.ToString();
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
