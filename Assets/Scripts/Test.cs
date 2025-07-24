using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject prefabCube;
    private GameObject[,] cubes;

    private Vector3 startPosition;

    private void Start()
    {
        cubes = new GameObject[10, 10];

        for (int i = 0; i < cubes.GetLength(0); i++)
        {

            for (int j = 0; j < cubes.GetLength(1); j++)
            {
                GameObject newCube = Instantiate(prefabCube, startPosition, Quaternion.identity);
                startPosition = new Vector3(startPosition.x + 1.05f, startPosition.y, startPosition.z);

            }
            startPosition.x = 0f;
            startPosition.y += 1.05f;
        }
    }
    // Hello World
}
