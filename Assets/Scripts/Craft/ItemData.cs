using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item_", menuName = "CreateItem_Craft", order = 51)]
public class ItemData : ScriptableObject
{
    [Header("ItemInfo")]
    public byte ID;
    public string Name;
    [TextArea(2, 4)] public string Description;
    public Sprite Sprite;

    [Header("ItemTypeAndStack")]
    public ItemTypes Type;
    public int MaxStackSize;




}
