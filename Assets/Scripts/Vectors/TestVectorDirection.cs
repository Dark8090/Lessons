using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestVectorDirection : MonoBehaviour
{
    [SerializeField] private Transform player;


    private void Update()
    {

        Vector3 mousePixelPos = Input.mousePosition;
        mousePixelPos.z = 10f;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePixelPos);

        Vector3 direction = (mouseWorldPos - player.position).normalized;  // Ќормализованный вектор или же вектор направлени€

        Debug.DrawLine(mouseWorldPos, player.position);

        //player.position = Vector3.MoveTowards(player.position, mouseWorldPos, distance * Time.deltaTime);
        //player.position += direction * 2f * Time.deltaTime;


        Vector3 distance = mouseWorldPos - player.position;
        float distanceMethod = Vector3.Distance(mouseWorldPos, player.position);
        print("Distance = " + distance);
        print("DistanceMethod = " + distanceMethod);

    }



}
