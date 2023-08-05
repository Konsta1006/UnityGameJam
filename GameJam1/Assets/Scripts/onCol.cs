using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class onCol : MonoBehaviour
{
    [SerializeField] UnityEvent eventX = new UnityEvent();
    [SerializeField] float radius = 1;
    void Update()
    {
        if (Physics.CheckSphere(transform.position, radius))
        {
            eventX.Invoke();
        }
    }

    public void Heal(GameObject particles)
    {
        GameObject.FindWithTag("player").GetComponent<PlayerDamage>().Heal(40);
        var x = Instantiate(particles);
        x.transform.position = transform.position;
        Destroy(gameObject);
    }
}
