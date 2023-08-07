using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cocumber : MonoBehaviour
{
    private GameObject player;
    Vector3 startpos;
    private void Start()
    {
        if (GameObject.FindWithTag("player") != null)
        {
            player = GameObject.FindWithTag("player");
        }
        
        startpos = transform.position;
    }
    void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 50f)
            {
                GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            }
            else
            {
                GetComponent<NavMeshAgent>().SetDestination(startpos);
            }
            
        }
        
    }
}
