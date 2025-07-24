using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVectorDot : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform cube;

    private void Update()
    {
        Vector3 direction = cube.position - player.position;
        //Vector3 direction = player.position - cube.position; // число отрицательное
        // По факту разницы 0, но нужно еще правильно логически подставлять
        float dot = Vector3.Dot(direction.normalized, cube.transform.right); // Я смотрю на цель и спрашиваю: она слева или справа от моего направления ? 
        float dot1 = Vector3.Dot(cube.transform.right, direction.normalized); //  Я смотрю на свой правый вектор и спрашиваю: он слева или справа от цели? 
        // т.е (a,b) - Объект А правее или левее?



        if (dot1 > 0)
            Debug.Log("Цель справа");
        else if (dot1 < 0)
            Debug.Log("Цель слева");
        else
            Debug.Log("Цель прямо");
    }
}
