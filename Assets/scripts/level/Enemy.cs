using UnityEngine;
using System.Collections;

public class Enemy : Entity
{
    public Vector2 speed;

    public void Update()
    {
        transform.position += (Vector3)speed * Time.deltaTime;
    }
}
