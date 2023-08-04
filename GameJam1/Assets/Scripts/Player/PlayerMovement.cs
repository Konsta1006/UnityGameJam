using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float speed;
    [SerializeField] float JumpForce;
    [SerializeField] GameObject knife;
    [SerializeField] LayerMask Ground;
    private Rigidbody rb;
    private Vector3 fix;
    private bool isGrounded;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        rb.AddForce(Vector3.down * 10f);
        Movement();
        LimitSpeed();
        Jump();
    }

    public void CopyCameraRotY()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y,transform.eulerAngles.z);
    }
    
    public void Movement()
    {
        int xAxis = System.Convert.ToInt32(Input.GetKey(KeyCode.W)) - System.Convert.ToInt32(Input.GetKey(KeyCode.S));
        int yAxis = System.Convert.ToInt32(Input.GetKey(KeyCode.D)) - System.Convert.ToInt32(Input.GetKey(KeyCode.A));
        
        rb.AddForce(transform.forward * xAxis * force);
        rb.AddForce(transform.right * yAxis * force);
        CopyCameraRotY();
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            fix = transform.eulerAngles;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.eulerAngles = fix;
        }
        
    }

    public void LimitSpeed()
    {
        Vector3 Speed = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (Speed.magnitude > speed)
        {
            Speed = rb.velocity.normalized * speed;
            rb.velocity = new Vector3(Speed.x,rb.velocity.y,Speed.z);
        }
        
    }

    public void Jump()
    {
        isGrounded = Physics.CheckSphere(transform.position - Vector3.up * 2.1f, 1f, Ground);
        if (isGrounded)
        {
            rb.drag = 5;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position - Vector3.up * 2.1f, 1f);
    }
}
