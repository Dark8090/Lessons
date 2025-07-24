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
        //Vector3 direction = player.position - cube.position; // ����� �������������
        // �� ����� ������� 0, �� ����� ��� ��������� ��������� �����������
        float dot = Vector3.Dot(direction.normalized, cube.transform.right); // � ������ �� ���� � ���������: ��� ����� ��� ������ �� ����� ����������� ? 
        float dot1 = Vector3.Dot(cube.transform.right, direction.normalized); //  � ������ �� ���� ������ ������ � ���������: �� ����� ��� ������ �� ����? 
        // �.� (a,b) - ������ � ������ ��� �����?



        if (dot1 > 0)
            Debug.Log("���� ������");
        else if (dot1 < 0)
            Debug.Log("���� �����");
        else
            Debug.Log("���� �����");
    }
}
