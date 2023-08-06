using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class onCol : MonoBehaviour
{
    [SerializeField] UnityEvent eventX = new UnityEvent();
    [SerializeField] float radius = 1;
    LayerMask mask;
    void Update()
    {
        mask = LayerMask.GetMask("Player");
        if (Physics.CheckSphere(transform.position, radius, mask))
        {
            eventX.Invoke();
            
        }
        
    }

    public void Heal(GameObject particles)
    {
        if (GameObject.FindWithTag("player").GetComponent<PlayerDamage>()!=null)
        {
            GameObject.FindWithTag("player").GetComponent<PlayerDamage>().Heal(40);
            var x = Instantiate(particles);
            x.transform.position = transform.position;
            Destroy(gameObject);
        }
        
    }

    public void beActive(GameObject obj)
    {
        if (Physics.CheckSphere(transform.position, radius*0.9f, mask))
        {
            Debug.Log("x");
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
