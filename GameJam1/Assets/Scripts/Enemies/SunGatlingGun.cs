using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SunGatlingGun : MonoBehaviour
{
    [SerializeField] Transform bulletStartPos;
    [SerializeField] GameObject bullet;
    [SerializeField] AudioClip clip;
    [SerializeField] UnityEvent eventX = new UnityEvent();
    void Start()
    {
        StartCoroutine(startShot());
    }

    private void Update()
    {
        gameObject.transform.Rotate(Time.deltaTime * 80, 0, 0);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            StopCoroutine(ShootingMode());
            eventX.Invoke();
            Destroy(gameObject);
        }
    }

    IEnumerator startShot()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(ShootingMode());
    }


    IEnumerator ShootingMode()
    {
        yield return new WaitForSeconds(0.4f);
        var a = Instantiate(bullet);
        
        a.transform.position = bulletStartPos.position;
        a.transform.eulerAngles = bulletStartPos.eulerAngles;
        
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
        a.transform.parent = null;
        
        StartCoroutine(ShootingMode());
        
    }
}
