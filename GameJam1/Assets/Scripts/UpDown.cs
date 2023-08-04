using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time), transform.position.z);
        transform.localScale = new Vector3(transform.localScale.y, Mathf.Sin(Time.time) * 10, Mathf.Sin(Time.time) * 10);
    }
}
