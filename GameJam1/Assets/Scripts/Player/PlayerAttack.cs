using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Animator>().SetBool("IsAttack", true);
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            GetComponent<Animator>().SetBool("IsAttack", false);
           
        }

    }

}
