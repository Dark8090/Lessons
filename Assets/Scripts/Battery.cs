using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public Gear gear;


    private void Update()
    {
        gear.Rotate(10f);
    }

}
