using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    [SerializeField] private InventorySystem Inventory;
    //[SerializeField] private ItemData[] item;


    //Buttons
    public void Create(CraftingRecipeData recipe)
    {
        if (!CanCraft(recipe))
        {
            print("Недостаточно ресурсов");
            return;
        }
        else
        {
            RemovingResources(recipe);
            CompleteCraft(recipe);
        }




    }
    private bool CanCraft(CraftingRecipeData recipe)
    {
        for (int i = 0; i < recipe.RequiredItemsForCraft.Length; i++)
        {
            ItemData requiredItem = recipe.RequiredItemsForCraft[i];
            int reuiredAmount = recipe.RequiredAmountsForCraft[i];
            int amount = 0; // сколько у нас есть

            for (int j = 0; j < Inventory.InventorySlot.Length; j++)
            {
                InventorySlot slot = Inventory.InventorySlot[j];

                if (slot.GetItem() != null && slot.GetItem().Type == requiredItem.Type && slot.GetItem().ItemData.ID == requiredItem.ID)
                {
                    amount += slot.GetItem().Amount; // суммируем кол-во во всех слотах
                }
            }
            if (amount < reuiredAmount)
            {
                return false;
            }
        }

        return true;
    }
    private void RemovingResources(CraftingRecipeData recipe)
    {
        for (int i = 0; i < recipe.RequiredItemsForCraft.Length; i++)
        {
            ItemData requiredItem = recipe.RequiredItemsForCraft[i];
            int amountToRemoving = recipe.RequiredAmountsForCraft[i];

            for (int j = 0; j < Inventory.InventorySlot.Length; j++)
            {
                InventorySlot slot = Inventory.InventorySlot[j];

                if (slot.GetItem() != null && slot.GetItem().Type == requiredItem.Type && slot.GetItem().ID == requiredItem.ID && amountToRemoving > 0)
                {
                    print($"Операция №{j}");
                    print($"ID слота {slot.GetItem().ID}, ID требуемого предмета {requiredItem.ID}");
                    

                    int removingThisSlot = Mathf.Min(amountToRemoving, slot.GetItem().Amount);
                    print($"Cлот {j}, удалил {removingThisSlot} шт., осталось  {slot.GetItem().Amount - removingThisSlot} шт");
                    slot.RemoveItem(removingThisSlot);
                    
                    amountToRemoving -= removingThisSlot;
                    print($"amountToRemoving = {amountToRemoving}");

                }
            }
        }
    }



    private void CompleteCraft(CraftingRecipeData recipe)
    {
        var resultItem = recipe.ResultItem;
        for (int i = 0; i < Inventory.InventorySlot.Length; i++)
        {
            if (Inventory.InventorySlot[i].IsEmpty)
            {
                Inventory.InventorySlot[i].SetSlot(resultItem, recipe.ResultAmountItem);
                break;
            }
        }


    }
}
