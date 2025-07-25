using System;
using UnityEngine;


public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    [SerializeField, Range(0, 32)] private byte amountItem;
}
