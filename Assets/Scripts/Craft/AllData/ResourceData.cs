using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource_", menuName = "Create Resource", order = 51)]
public class ResourceData : ItemData
{
    [Header("Craft")]
    public bool isForCrafting = true;
}
