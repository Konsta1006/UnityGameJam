using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] float HP = 100f;
    [SerializeField] Slider HPbar;
    [SerializeField] GameObject body;
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
        var x = Instantiate(body);
        x.transform.position = transform.position;
        Destroy(gameObject);
    }

    public void Heal(float heal)
    {
        HP = Mathf.Clamp(HP + heal,0,startHP);
    }
}
