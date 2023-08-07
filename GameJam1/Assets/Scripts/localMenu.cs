using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchMenu();
        }
    }

    public void SwitchMenu()
    {
        
        if (!menu.activeSelf)
        {
            menu.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 1;
        }
        else
        {
            menu.SetActive(true);
            Time.timeScale = 0.1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
