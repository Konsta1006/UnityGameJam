using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt_forEyes : MonoBehaviour
{
    [SerializeField] GameObject target;
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform.position, Vector3.up);
        }
       
    }
}
