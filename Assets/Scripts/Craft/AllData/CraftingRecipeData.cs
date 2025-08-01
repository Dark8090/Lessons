using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe_", menuName = "Create Recipe", order = 51)]
public class CraftingRecipeData : ScriptableObject
{
    [Header("Recipe")]
    public RecipeType RecipeType;
    public ItemData[] RequiredItemsForCraft;
    public int[] RequiredAmountsForCraft;
    public bool[] checkRequiredItem;
    public Item ResultItem;
    public int ResultAmountItem;
    


}
