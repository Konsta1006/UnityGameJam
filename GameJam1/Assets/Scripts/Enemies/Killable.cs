using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [SerializeField] GameObject particle;
    [SerializeField] GameObject destroy;
    private void OnCollisionEnter(Collision collision)
    
    {
        if (collision.gameObject.layer == 6)
        {
            var x = Instantiate(particle);
            x.transform.position = transform.position;
            Destroy(destroy);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            var x = Instantiate(particle);
            x.transform.position = transform.position;
            Destroy(destroy);
        }
    }

    
}
