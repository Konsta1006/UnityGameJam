using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healrotation : MonoBehaviour
{
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + Vector3.up * Mathf.Sin(Time.time * 0.5f) * 0.1f;
        
    }
}
