using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] float HP = 100f;
    [SerializeField] Slider HPbar;
    float startHP;

    private void Start()
    {
        startHP = HP;
    }


    void Update()
    {
        HPbar.value = HP/startHP;
        if (HP <= 0)
        {
            Death();
        }
    }

    public void Damage(float damage)
    {
        HP -= damage;
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
