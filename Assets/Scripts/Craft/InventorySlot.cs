using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class InventorySlot : MonoBehaviour  
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Text countText;
    [SerializeField] private GameObject slot;
    [SerializeField] private bool isEmpty;

    private Item item;

    public void SetSlot(Item newItem)
    {
        item = newItem;

        if (newItem != null)
        {
            iconImage.sprite = newItem.Sprite;
            iconImage.enabled = true;

            if (newItem.ItemData.MaxStackSize > 1)
            {
                countText.text = newItem.Amount.ToString();
                countText.enabled = true;
            }
            else
            {
                countText.enabled = false;
            }

            //slot.SetActive(true);

        }
    }

    public void ClearSlot()
    {
        item = null;
        //slot.SetActive(false);
        iconImage.sprite = null;
        countText.text = null;
    }
    public void UpdateCount()
    {
        if (item != null && item.ItemData.MaxStackSize > 1)
        {
            countText.text = item.Amount.ToString();
        }
    }

    public Item GetItem() => item;
}
