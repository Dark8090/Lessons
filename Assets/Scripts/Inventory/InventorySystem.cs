using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private int countSlots;
    [SerializeField] private GameObject slotPrefab;

    [SerializeField] private ItemInfo[] allItems;

    private Slot[] slots;

    private void Start()
    {
        CreateSlots();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            AddItemInInventory();
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            RemoveItemInInventory();
        }
    }
    private void AddItemInInventory()
    {
        int y = Random.Range(0, allItems.Length);

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsEmpty == false)
            {
                slots[i].SetSlot(allItems[y].Sprite);
                break;
            }
        }
    }

    private void RemoveItemInInventory()
    {
        for (int i = slots.Length - 1; i >= 0; i--)
        {
            if (slots[i].IsEmpty == true)
            {
                slots[i].RemoveSlot();
                break;
            }
        }
    }

    private void CreateSlots()
    {
        slots = new Slot[countSlots];

        for (int i = 0; i < slots.Length; i++)
        {
            GameObject slot = Instantiate(slotPrefab, transform);
            slots[i] = slot.GetComponent<Slot>();
        }
    }
}
