using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKforLegs : MonoBehaviour
{
    [SerializeField] GameObject leg1;
    [SerializeField] GameObject leg2;
    [SerializeField] GameObject target;
    [SerializeField] float boneLength;
    private float angle1;
    private float angle2;

    public void CalculateAngles()
    {
        float dist = Vector3.Distance(transform.position, target.position); 
        float alpha = 1;
    }
}
