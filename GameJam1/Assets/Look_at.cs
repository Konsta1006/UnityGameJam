using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_at : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;

    void Update()
    {
        if (target != null)
        {
            // �������� ����������� � ����
            Vector3 directionToTarget = target.position - transform.position;

            // ������������ ������ � ����������� ���� � ������� ���������
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
        }
    }
}

