using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy {

    public float vSpeed;
    public float minY;
    public float projectileSpeed;
    public Projectile projectile;
    public float shootingRate;
    private float shootingCounter = 0;

    public new void Awake()
    {
        base.Awake();
    }

    public new void Start () {
        base.Start();
        speed.y = -vSpeed;
	}

    public new void Update()
    {
        base.Update();
        if(transform.position.y <= minY)
        {
            Die();
            return;
        }
        shootingCounter += Time.deltaTime;
        if (shootingCounter >= shootingRate)
        {
            Vector2 auxVector = Player.player.transform.position - transform.position;
            auxVector.Normalize();
            auxVector *= projectileSpeed;
            Projectile auxProjectile = Instantiate<GameObject>(projectile.gameObject, transform.position, Quaternion.identity)
                .GetComponent<Projectile>();
            auxProjectile.speed = auxVector;
            auxProjectile.enemyProjectile = true;
            shootingCounter -= shootingRate;
        }
    }
}
