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
        CraftingRecipeData buffer = recipe;
        for (int i = 0; i < recipe.RequiredItemsForCraft.Length; i++) // 2
        {
            for (int j = 0; j < Inventory.InventorySlot.Length; j++) // 18
            {
                if (Inventory.InventorySlot[j].GetItem() != null)
                {
                    if (Inventory.InventorySlot[j].GetItem().Type == recipe.RequiredItemsForCraft[i].Type &&
                        Inventory.InventorySlot[j].GetItem().Amount >= recipe.RequiredAmountsForCraft[i]) // —лот 0 == в рецепте 0(false), слот 1 == в рецепте 0(true), ищем пока не найдем нужный тип
                                                                                                          // —лот 1 >= в рецепте 0(false), нашли нужный тип - слот 9 >= в рецепте 0(true)
                    {


                        // тут нужна логика, с проверкой найденных предметов, если все предметы из RequiredItemsForCraft найдены и кол-ва хватает, то мы вычитаем/удал€ем слоты найденых предметов
                        // и выдаем созданный предмет.
                        recipe.checkRequiredItem[i] = true;

                        if (recipe.checkRequiredItem.All(x => x))
                        {
                            CompleteCraft(buffer);
                            buffer = null;

                        }

                        break; // 1 ресурс проверили, вычли кол-во/удалили, ѕќ—“ј¬»Ћ» чек бокс TRUE дл€ 1 ресурса

                    }

                }
            }
        }

    }

    private void CompleteCraft(CraftingRecipeData recipe)
    {
        for (int i = 0; i < recipe.RequiredItemsForCraft.Length; i++)
        {
            for (int j = 0; j < Inventory.InventorySlot.Length; j++) // 18
            {
                if (Inventory.InventorySlot[j].GetItem() != null)
                {
                    if (Inventory.InventorySlot[j].GetItem().Type == recipe.RequiredItemsForCraft[i].Type) // —лот 0 == в рецепте 0(false), слот 1 == в рецепте 0(true), ищем пока не найдем нужный тип
                    {
                        if (Inventory.InventorySlot[j].GetItem().Amount >= recipe.RequiredAmountsForCraft[i]) // —лот 1 >= в рецепте 0(false), нашли нужный тип - слот 9 >= в рецепте 0(true)
                        {
                            Inventory.InventorySlot[j].GetItem().Amount -= recipe.RequiredAmountsForCraft[i];
                            if (Inventory.InventorySlot[j].GetItem().Amount <= 0)
                            {
                                Inventory.InventorySlot[j].ClearSlot();
                            }
                        }

                    }
                }


            }
        }

        for (int i = 0; i < Inventory.InventorySlot.Length; i++)
        {
            if (Inventory.InventorySlot[i].IsEmpty)
            {
                Inventory.InventorySlot[i].SetSlot(recipe.ResultItem, recipe.ResultAmountItem);
                break;
            }
        }
    }
}
