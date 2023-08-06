using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<PlayerDamage>().Damage(9999999);
        }
    }
}
