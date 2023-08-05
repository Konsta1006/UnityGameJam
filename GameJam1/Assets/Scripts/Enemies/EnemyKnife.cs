using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnife : MonoBehaviour
{
    [SerializeField] float rad;
    
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, rad);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.layer == 7)
            {
                hitCollider.gameObject.GetComponent<PlayerDamage>().Damage(30);
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,rad);
    }
}
