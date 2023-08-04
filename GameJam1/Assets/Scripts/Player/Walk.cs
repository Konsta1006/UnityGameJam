using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] LayerMask Ground;
    [SerializeField] GameObject legTarget;
    [SerializeField] Vector3 Offset;
    [SerializeField] float StartOffset;
    [SerializeField] float distance;
    private GameObject offset;
    private Vector3 fixedPos;
    private GameObject parent;
    private void Start()
    {
        offset = new GameObject();
        parent = transform.parent.gameObject;
        offset.transform.parent = parent.transform;
        offset.transform.localPosition = Offset;
        Vector3 target = offset.transform.position + StartOffset * parent.transform.forward;
        if (Physics.Raycast(target, Vector3.down, out RaycastHit hit, 5f, Ground))
        {
            legTarget.transform.position = hit.point;
        }
    }
    void Update()
    {
        Vector3 target = offset.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(target, Vector3.down, out hit, 5f, Ground))
        {
            if (Vector3.Distance(legTarget.transform.position, hit.point)>distance)
            {
                fixedPos = hit.point;
                //fixedPos = Vector3.Lerp(fixedPos, hit.point, Time.deltaTime * 6);
            }
        }
        legTarget.transform.position = fixedPos;
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(new Vector3(Offset.x + transform.position.x, transform.position.y, transform.position.z + Offset.y), 0.4f) ;
        
    }
}
