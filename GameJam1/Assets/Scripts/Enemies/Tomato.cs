using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Tomato : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(player.position);
    }
}
