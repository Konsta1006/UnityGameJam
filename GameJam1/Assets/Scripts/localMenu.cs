using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    private void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchMenu();
        }
    }

    public void SwitchMenu()
    {
        
        if (menu.activeSelf)
        {
            menu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
        else
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
