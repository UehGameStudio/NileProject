using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    public Rect spawnArea;
    public float spawnRate;
    private float spawnCounter = 0;

    public void Update()
    {
        spawnCounter += Time.deltaTime;
        if(spawnCounter >= spawnRate)
        {
            Vector3 spawnPos = transform.position;
            spawnPos.x = Random.Range(spawnArea.xMin, spawnArea.xMax);
            spawnPos.y = Random.Range(spawnArea.yMin, spawnArea.yMax);
            Instantiate<GameObject>(enemy.gameObject, spawnPos, Quaternion.identity);
            spawnCounter -= spawnRate;
        }
    }
}
