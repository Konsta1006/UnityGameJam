using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] LayerMask Ground;
    [SerializeField] GameObject legTarget;
    [SerializeField] Vector2 BaseOffset;
    [SerializeField] float distance;
    [SerializeField] Rigidbody parent;
    [SerializeField] float targetRbMult;
    [SerializeField] float MinBodyDist;
    private Vector3 fixedPos;
    private Vector3 target;
    

    

    private void Start()
    {
        CalculateLegPosition();
    }

    void Update()
    {
        CalculateLegPosition();
        CheckForBody();
    }

    public void CalculateLegPosition()
    {
        target = parent.velocity*targetRbMult + parent.gameObject.transform.position + parent.transform.forward * BaseOffset.x + parent.transform.right * BaseOffset.y;
        RaycastHit hit;
        if (Physics.Raycast(target, Vector3.down, out hit, 5f, Ground))
        {
            if (Vector3.Distance(legTarget.transform.position, hit.point) > distance)
            {
                fixedPos = hit.point;
                if (GetComponent<PlayRandSound>() != null)
                {
                    GetComponent<PlayRandSound>().PlayRandomSound();
                }
            }
        }
        //legTarget.transform.position = fixedPos;
        legTarget.transform.position = Vector3.Slerp(legTarget.transform.position, fixedPos, Time.deltaTime * 16);
    }

    public void CheckForBody()
    {
        target = parent.velocity * targetRbMult + parent.gameObject.transform.position + parent.transform.forward * BaseOffset.x + parent.transform.right * BaseOffset.y;
        if (Physics.Raycast(parent.transform.position,Vector3.down,out RaycastHit hit, 10f, Ground))
        {

            if (Vector3.Distance(legTarget.transform.position, hit.point) < MinBodyDist)
            {
                if (Physics.Raycast(target, Vector3.down, out hit, 5f, Ground))
                {

                    fixedPos = hit.point;

                }
            }
        }
        legTarget.transform.position = Vector3.Slerp(legTarget.transform.position, fixedPos, Time.deltaTime * 16); 
    }

    private void OnDrawGizmos()
    {
        target = parent.velocity * targetRbMult + parent.gameObject.transform.position + parent.transform.forward * BaseOffset.x + parent.transform.right * BaseOffset.y;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(target, 0.4f) ;
        
    }
}
