using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcanoid : MonoBehaviour
{

    private Vector3 direction = new Vector3(1f,1f,0f);
    private Vector3 position;

    private float speed = 5f;
    private float radius = 0.5f;
    public LayerMask collisionMask;

    private void Start()
    {
        position = transform.position;
    }
    private void FixedUpdate()
    {

        Move();
    }

    private void Move()
    {
        Vector3 moveStep = direction * speed * Time.fixedDeltaTime;
        print("BaseMoveStep =" + moveStep.magnitude);
        // ���������, �� ��������� �� ������������ �� ����
        if (Physics.SphereCast(position, radius, direction, out RaycastHit hit, moveStep.magnitude, collisionMask))
        {
            print("Hit MoveStep = " + moveStep.magnitude);
            // ����� �� ����� � ��������� �� ����� �������
            transform.position = position + direction * hit.distance;

            // �������� ����������� �� �������
            direction = Vector3.Reflect(direction, hit.normal);

            
            transform.position += hit.normal * 0.05f;

            // ��������� ������� ����� �������
            position = transform.position;
        }
        else
        {
            // ��� ����������� � ���������� ��������
            position += direction * speed * Time.fixedDeltaTime;
            transform.position = position;
        }
    }
    
   
}
