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
        RaycastHit[] colliders = Physics.BoxCastAll(transform.position, GetComponent<BoxCollider>().size + new Vector3(0, 0.5f, 0), Vector3.zero, Quaternion.Euler(0,0,0), 0f, player);
        if (colliders != null)
        {
            A = true;
            if (A == true && B == false)
            {
                colliders[0].collider.gameObject.GetComponent<Rigidbody>().AddForce(JumpForce, ForceMode.Impulse);
            }
            
        }
        else
        {
            A = false;
        }
        B = A;
    }
}
