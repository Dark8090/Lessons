using System;
using UnityEngine;

[Serializable]
public abstract class Item
{
    [SerializeField] protected ItemData itemData;
    [SerializeField] protected int amount;

    public ItemData ItemData => itemData;
    public int Amount { get; protected set; }

    public int ID => ItemData.ID;
    public string Name => ItemData.Name;
    public string Description => ItemData.Description;
    public Sprite Sprite => ItemData.Sprite;
    public ItemTypes Type => ItemData.Type;
    public int MaxStackSize => ItemData.MaxStackSize;


    public bool CanAdd(int amount) => Amount + amount <= MaxStackSize;
    public bool CanStackWith(Item item) => item != null && ID == item.ID && Amount < MaxStackSize;

    /// <summary>
    /// Use item.
    /// </summary>
    public virtual void Use() { }

    /// <summary>
    /// Get the amount of unallocated space before MaxStackSize is filled. 
    /// </summary>
    /// <returns></returns>
    public int GetRemainingSpace() => MaxStackSize - Amount;


    public abstract Item Clone();
}
