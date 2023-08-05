using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cocumber : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if (player != null)
        {
            GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }
        
    }
}
