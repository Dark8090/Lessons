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
        //CraftingRecipeData buffer = recipe;
        //for (int i = 0; i < recipe.RequiredItemsForCraft.Length; i++) // 2
        //{
        //    for (int j = 0; j < Inventory.InventorySlot.Length; j++) // 18
        //    {
        //        if (Inventory.InventorySlot[j].GetItem() != null)
        //        {
        //            if (Inventory.InventorySlot[j].GetItem().Type == recipe.RequiredItemsForCraft[i].Type &&
        //                Inventory.InventorySlot[j].GetItem().Amount >= recipe.RequiredAmountsForCraft[i]) // Слот 0 == в рецепте 0(false), слот 1 == в рецепте 0(true), ищем пока не найдем нужный тип
        //                                                                                                  // Слот 1 >= в рецепте 0(false), нашли нужный тип - слот 9 >= в рецепте 0(true)
        //            {


        //                // тут нужна логика, с проверкой найденных предметов, если все предметы из RequiredItemsForCraft найдены и кол-ва хватает, то мы вычитаем/удаляем слоты найденых предметов
        //                // и выдаем созданный предмет.
        //                recipe.checkRequiredItem[i] = true;

        //                if (recipe.checkRequiredItem.All(x => x))
        //                {
        //                    CompleteCraft(buffer);
        //                    buffer = null;

        //                }

        //                break; // 1 ресурс проверили, вычли кол-во/удалили, ПОСТАВИЛИ чек бокс TRUE для 1 ресурса

        //            }

        //        }
        //    }
        //}

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
            ItemData requiredItem = recipe.RequiredItemsForCraft[0];
            int reuiredAmount = recipe.RequiredAmountsForCraft[0];
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
            ItemData requiredItem = recipe.RequiredItemsForCraft[0];
            int amountToRemoving = recipe.RequiredAmountsForCraft[0];

            for (int j = 0; j < Inventory.InventorySlot.Length; j++)
            {
                InventorySlot slot = Inventory.InventorySlot[j];

                if (slot.GetItem() != null && slot.GetItem().Type == requiredItem.Type && slot.GetItem().ID == requiredItem.ID)
                {
                    int removingThisSlot = Mathf.Min(amountToRemoving, slot.GetItem().Amount);
                    slot.RemoveItem(removingThisSlot);
                    amountToRemoving -= removingThisSlot;
                    print($"Слот {j}, удаляю предмет {requiredItem}, должно остаться {amountToRemoving}");

                }
            }
        }
    }



    private void CompleteCraft(CraftingRecipeData recipe)
    {
        //for (int i = 0; i < recipe.RequiredItemsForCraft.Length; i++)
        //{
        //    for (int j = 0; j < Inventory.InventorySlot.Length; j++) // 18
        //    {
        //        if (Inventory.InventorySlot[j].GetItem() != null)
        //        {
        //            if (Inventory.InventorySlot[j].GetItem().Type == recipe.RequiredItemsForCraft[i].Type) // Слот 0 == в рецепте 0(false), слот 1 == в рецепте 0(true), ищем пока не найдем нужный тип
        //            {
        //                if (Inventory.InventorySlot[j].GetItem().Amount >= recipe.RequiredAmountsForCraft[i]) // Слот 1 >= в рецепте 0(false), нашли нужный тип - слот 9 >= в рецепте 0(true)
        //                {
        //                    Inventory.InventorySlot[j].GetItem().Amount -= recipe.RequiredAmountsForCraft[i];
        //                    if (Inventory.InventorySlot[j].GetItem().Amount <= 0)
        //                    {
        //                        Inventory.InventorySlot[j].ClearSlot();
        //                    }
        //                }

        //            }
        //        }


        //    }
        //}

        //for (int i = 0; i < Inventory.InventorySlot.Length; i++)
        //{
        //    if (Inventory.InventorySlot[i].IsEmpty)
        //    {
        //        Inventory.InventorySlot[i].SetSlot(recipe.ResultItem, recipe.ResultAmountItem);
        //        break;
        //    }
        //}

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
