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
        //                Inventory.InventorySlot[j].GetItem().Amount >= recipe.RequiredAmountsForCraft[i]) // ���� 0 == � ������� 0(false), ���� 1 == � ������� 0(true), ���� ���� �� ������ ������ ���
        //                                                                                                  // ���� 1 >= � ������� 0(false), ����� ������ ��� - ���� 9 >= � ������� 0(true)
        //            {


        //                // ��� ����� ������, � ��������� ��������� ���������, ���� ��� �������� �� RequiredItemsForCraft ������� � ���-�� �������, �� �� ��������/������� ����� �������� ���������
        //                // � ������ ��������� �������.
        //                recipe.checkRequiredItem[i] = true;

        //                if (recipe.checkRequiredItem.All(x => x))
        //                {
        //                    CompleteCraft(buffer);
        //                    buffer = null;

        //                }

        //                break; // 1 ������ ���������, ����� ���-��/�������, ��������� ��� ���� TRUE ��� 1 �������

        //            }

        //        }
        //    }
        //}

        if (!CanCraft(recipe))
        {
            print("������������ ��������");
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
            int amount = 0; // ������� � ��� ����

            for (int j = 0; j < Inventory.InventorySlot.Length; j++)
            {
                InventorySlot slot = Inventory.InventorySlot[j];

                if (slot.GetItem() != null && slot.GetItem().Type == requiredItem.Type && slot.GetItem().ItemData.ID == requiredItem.ID)
                {
                    amount += slot.GetItem().Amount; // ��������� ���-�� �� ���� ������
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
                    print($"���� {j}, ������ ������� {requiredItem}, ������ �������� {amountToRemoving}");

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
        //            if (Inventory.InventorySlot[j].GetItem().Type == recipe.RequiredItemsForCraft[i].Type) // ���� 0 == � ������� 0(false), ���� 1 == � ������� 0(true), ���� ���� �� ������ ������ ���
        //            {
        //                if (Inventory.InventorySlot[j].GetItem().Amount >= recipe.RequiredAmountsForCraft[i]) // ���� 1 >= � ������� 0(false), ����� ������ ��� - ���� 9 >= � ������� 0(true)
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
