using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Tomato : MonoBehaviour
{
    public Transform player;
    public Transform minigun;
    public Transform bulletStartPos;
    public GameObject bullet;
    public GameObject BulletParticle;
    public AudioClip clip;
    bool going1;
    bool going2;
    bool stopfire = true;
    void Update()
    {
        NavMeshAgent nav = GetComponent<NavMeshAgent>();
        if (Vector3.Distance(transform.position, player.transform.position) > 8f)
        {
            going1 = true;
            nav.SetDestination(player.transform.position);
        }
        else
        {

            going1 = false;
            minigun.Rotate(Time.deltaTime*8, 0, 0);
            if (!going1 && going2)
            {
                stopfire = false;
                StartCoroutine(ShootingMode());
            }
        }
        going2 = going1;
        
        
    }


    IEnumerator ShootingMode()
    {
        yield return new WaitForSeconds(0.1f);
        var a = Instantiate(bullet);
        var b = Instantiate(BulletParticle);
        a.transform.position = bulletStartPos.position;
        a.transform.eulerAngles = bulletStartPos.eulerAngles;
        b.transform.position = bulletStartPos.position;
        b.GetComponent<AudioSource>().clip = clip;
        b.GetComponent<AudioSource>().Play();
        a.transform.parent = null;
        if (!stopfire)
        {
            StartCoroutine(ShootingMode());
        }
    }
}
