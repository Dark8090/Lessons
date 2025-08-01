using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject panelSlots;
    [SerializeField] private GameObject prefabSlot;

    [SerializeField] private InventorySlot[] slots;
    [SerializeField] private List<InventoryItem> items;

    private int maxSlots = 18;

    public InventorySlot[] InventorySlot { get => slots; set => slots = value; }

    private void Start()
    {
        CreateSlots(maxSlots);
    }
    private void CreateSlots(int countSlots)
    {
        slots = new InventorySlot[countSlots];

        for (int i = 0; i < countSlots; i++)
        {
            GameObject newSlot = Instantiate(prefabSlot, panelSlots.transform);
            slots[i] = newSlot.GetComponent<InventorySlot>();
        }
    }

    //Button
    public void UpdateInfo()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetItem() != null)
            {

                slots[i].UpdateAllInfo();
            }
        }
    }

    public void FillRandom()
    {
        for (int i = 0; i < slots.Length / 2; i++)
        {
            if (slots[i].GetItem() == null)
            {
                slots[i].SetSlot(items[UnityEngine.Random.Range(0, items.Count)].item.itemPrefab, UnityEngine.Random.Range(0, 5));
            }
        }
        //UpdateInfo();
    }



}

[Serializable]
public class InventoryItem
{
    public ItemData item;

}