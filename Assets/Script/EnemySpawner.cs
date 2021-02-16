using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    private float spawnTime = 4.0f;
    public float curTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime >= spawnTime)
        {
            SpawnEnemy();
        }
        curTime += Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        Vector3 position = new Vector3(Random.Range(-4.0f, 4.0f), 0, Random.Range(-3.0f, 0f));
        curTime = 0;
        Instantiate(Enemy, position, Quaternion.identity);
    }
}
