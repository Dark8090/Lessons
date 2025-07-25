using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item_",menuName = "CreateItem_Craft", order = 51)]
public class ItemData : ScriptableObject
{
    [Header("Item")]
    public byte ItemID;
    public RecipeType RecipeType;
    public string ItemName;
    public string Description;
    public Image Image;
    
}
