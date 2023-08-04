using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time), transform.position.z);
        transform.localScale = new Vector3(Mathf.Sin(Time.time), transform.localScale.y, transform.localScale.z);
    }
}
