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
            // Получаем направление к цели
            Vector3 directionToTarget = target.position - transform.position;

            // Поворачиваем объект в направлении цели с плавным поворотом
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
        }
    }
}

