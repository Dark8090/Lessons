using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReflectedWall : MonoBehaviour
{
    [SerializeField] private Transform cube;
    [SerializeField] private float speed;
    private Vector3 velocity; // направление и скорость, Мозговой Бэээм

    private void Start()
    {
        velocity = new Vector3(5f, 0f, 0f);
    }
    private void Update()
    {
        Ray ray = new Ray(cube.transform.position, cube.transform.right);
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.green);
        if (Physics.Raycast(ray, out RaycastHit hit, 2f))
        {
            if (hit.collider)
            {
                velocity = Vector3.Reflect(velocity , hit.normal);
                cube.rotation = Quaternion.LookRotation(hit.normal, transform.forward);
            }
        }   
        cube.position += velocity.normalized * speed * Time.deltaTime;
    }
}
