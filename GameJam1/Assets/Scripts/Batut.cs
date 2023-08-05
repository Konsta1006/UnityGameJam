using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batut : MonoBehaviour
{
    public LayerMask player;
    public Vector3 JumpForce;
    bool A=true;
    bool B=true;
    void Update()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, GetComponent<BoxCollider>().size + new Vector3(0, 1f, 0), Quaternion.Euler(0, 0, 0), player);

        if (colliders.Length > 0)
        {

            A = true;
            if (A == true && B == false)
            {
                colliders[0].gameObject.GetComponent<Rigidbody>().AddForce(JumpForce, ForceMode.Impulse);
            }
            
        }
        else
        {
            A = false;
        }
        B = A;
    }
}
