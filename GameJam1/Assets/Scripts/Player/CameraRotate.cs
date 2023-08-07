using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] float distance;
    Vector3 offset;
    float angleX;
    float angleY;
    //[SerializeField] float sens;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindWithTag("player");
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (Player != null)
        {
            
            angleX -= Input.GetAxis("Mouse Y") * PlayerPrefs.GetFloat("Sens");
            angleY += Input.GetAxis("Mouse X") * PlayerPrefs.GetFloat("Sens");
            angleX = Mathf.Clamp(angleX, 5, 90);

            Vector3 TargetRot = new Vector3(angleX, angleY);

            transform.eulerAngles = TargetRot;

            transform.position = Player.transform.position - transform.forward * distance;
        }
        
        

    }
}
