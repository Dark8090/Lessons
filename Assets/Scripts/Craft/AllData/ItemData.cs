using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item_", menuName = "CreateItem_Craft", order = 51)]
public class ItemData : ScriptableObject
{
    [Header("ItemInfo")]
    public int ID;
    public string Name;
    [TextArea(2, 4)] public string Description;
    public Sprite Sprite;
    public Item itemPrefab;

    [Header("ItemTypeAndStack")]
    public ItemTypes Type;
    public int MaxStackSize;




}
