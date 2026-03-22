using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public GameObject[] Enemys;
    public float spawnDistance = 80.0f;
    public float spawnInterval = 3.0f;
    public float spanInitinterval = 2.0f;
    [SerializeField]
    private int maxEnemies = 0;
    private int enemyType = 0;
    [SerializeField]
    public int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("Spawn", spanInitinterval, spawnInterval);
    }

    void Spawn()
    {
        if (enemyCount >= maxEnemies)
        {
            return;
        }
        Vector2 randomCircle = Random.insideUnitCircle.normalized;
        Vector3 spawnPos = new Vector3(player.position.x + randomCircle.x * spawnDistance, 1, player.position.z + randomCircle.y * spawnDistance);
        GameObject enemy = Instantiate(Enemys[Random.Range(0, enemyType)], spawnPos, Quaternion.identity);
        enemyCount++;
    }

    public void BossSpawn()
    {
        //Vector2 randomCircle = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
