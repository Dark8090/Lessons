using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject panelSlots;
    [SerializeField] private GameObject prefabSlot;
    [SerializeField] private InventorySlot[] slots;

    private int maxSlots = 18;

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
}
