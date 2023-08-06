using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(0, -speed * Time.deltaTime, 0, Space.Self);
    }
}
