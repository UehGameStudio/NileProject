using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float lifetime;
    public float damage;
    public Vector2 speed;
    [HideInInspector]
    public bool enemyProjectile;

    public void Hit(Entity entity)
    {
        entity.TakeDamage(damage);
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Entity auxEntity = collision.GetComponent<Entity>();
        if(auxEntity is Player == enemyProjectile)
        {
            Hit(auxEntity);
        }
    }

    public void Update()
    {
        transform.position += (Vector3)speed * Time.deltaTime;
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Die();
        }
    }

}
