using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] float distance;
    Vector3 offset;
    float angleX;
    float angleY;
    [SerializeField] float sens;
    [SerializeField] GameObject Player;

    void Start()
    {

    }


    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        angleX -= Input.GetAxis("Mouse Y") * sens;
        angleY += Input.GetAxis("Mouse X") * sens;
        angleX = Mathf.Clamp(angleX, 5, 90);

        Vector3 TargetRot = new Vector3(angleX, angleY);

        transform.eulerAngles = TargetRot;

        transform.position = Player.transform.position - transform.forward * distance;


    }
}