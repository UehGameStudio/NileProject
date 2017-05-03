using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public float maxLife;
    public float life;

    public void Awake()
    {
        life = maxLife;
    }

    public void Start() { }

    public void TakeDamage(float damage)
    {
        if (life > damage)
        {
            life -= damage;
        }
        else
        {
            life = 0;
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
