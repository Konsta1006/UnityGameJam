using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityControl : MonoBehaviour
{

    private void Start()
    {
        gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Sens");
        gameObject.GetComponent<Slider>().onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        
        PlayerPrefs.SetFloat("Sens", gameObject.GetComponent<Slider>().value);
    }
}
