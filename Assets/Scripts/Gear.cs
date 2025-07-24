using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public Gear[] gears;


    public void Rotate(float direction)
    {
        transform.Rotate(0f, 0f, direction * Time.deltaTime);
        foreach (Gear gear in gears)
        {
            gear.Rotate(-direction);
        }

        
    }
}

