using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float delay;
    void Start()
    {
        StartCoroutine(Destroyk());
    }

   IEnumerator Destroyk()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
