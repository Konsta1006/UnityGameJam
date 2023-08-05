using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject particles;
    [SerializeField] LayerMask Player;
    [SerializeField] LayerMask Ground;
    
    
    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
        collisionDetect();
    }

    void collisionDetect()
    {
        Ray ray = new Ray(transform.position, -transform.right);
        if (Physics.Raycast(ray, out RaycastHit hit, speed*Time.deltaTime, Player))
        {
            var x = Instantiate(particles);
            x.transform.position = hit.point;
            Destroy(gameObject);
        }
        if (Physics.Raycast(ray, out RaycastHit hit1, speed * Time.deltaTime, Ground))
        {
            var x = Instantiate(particles);
            x.transform.position = hit1.point;
            Destroy(gameObject);
        }
    }
}
