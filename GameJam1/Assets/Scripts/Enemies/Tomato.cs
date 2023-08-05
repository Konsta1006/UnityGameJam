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
    bool Agressive = false;
    Vector3 StartPos;

    private void Start()
    {
        StartPos = transform.position;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 50f)
        {
            Agressive = true;
        }
        else
        {
            NavMeshAgent nav = GetComponent<NavMeshAgent>();
            Agressive = false;
            nav.SetDestination(StartPos);
        }
        if (Agressive)
        {
            NavMeshAgent nav = GetComponent<NavMeshAgent>();
            if (Vector3.Distance(transform.position, player.transform.position) > 25f)
            {
                nav.speed = 5.5f;
                going1 = true;
                nav.SetDestination(player.transform.position);
                stopfire = true;
            }
            else
            {
                nav.speed = 0.1f;
                RotateTowards();
                going1 = false;
                minigun.Rotate(Time.deltaTime * 500, 0, 0);
                if (!going1 && going2)
                {
                    stopfire = false;
                    StartCoroutine(ShootingMode());
                }
            }
            going2 = going1;
        }
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

    private void RotateTowards()
    {
        transform.LookAt(player.transform.position);
        
    }
}
