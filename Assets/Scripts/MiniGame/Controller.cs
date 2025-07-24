using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float speed = 3f;


    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Vector3 newPosition = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f);
            newPosition.x = Mathf.Clamp(newPosition.x, -8.5f, 8.5f);
            transform.position = newPosition;
        }

    }
}
