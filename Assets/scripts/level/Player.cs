using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    public static Player player;
    public float projectileSpeed;
    public Projectile projectile;
    public float rateOfFire;
    private float fireCounter;

    public const float SPEED = 5;
    public Rect gameBorders;

    public new void Awake()
    {
        base.Awake();
        fireCounter = rateOfFire;
        if(player != null)
        {
            Destroy(player.gameObject);
        }
        player = this;
    }

    private void CheckBorders()
    {
        Vector3 auxPos = transform.position;
        if(transform.position.x < gameBorders.xMin)
        {
            auxPos.x = gameBorders.xMin;
        }
        else if(transform.position.x > gameBorders.xMax)
        {
            auxPos.x = gameBorders.xMax;
        }
        if (transform.position.y < gameBorders.yMin)
        {
            auxPos.y = gameBorders.yMin;
        }
        else if (transform.position.y > gameBorders.yMax)
        {
            auxPos.y = gameBorders.yMax;
        }
        transform.position = auxPos;
    }

    private void Shoot()
    {
        Vector2 auxVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        auxVector.Normalize();
        auxVector *= projectileSpeed;
        Projectile auxProjectile = Instantiate<GameObject>(projectile.gameObject, transform.position, Quaternion.identity)
            .GetComponent<Projectile>();
        auxProjectile.speed = auxVector;
        auxProjectile.enemyProjectile = false;
    }

    public void Update()
    {
        Vector2 auxMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        auxMove = Vector2.ClampMagnitude(auxMove, 1);
        transform.position += (Vector3)auxMove * SPEED * Time.deltaTime;
        CheckBorders();
        fireCounter -= Time.deltaTime;
        if (Input.GetMouseButton(0) && fireCounter <= 0)
        {
            Shoot();
            fireCounter = rateOfFire;
        }
    }
}
