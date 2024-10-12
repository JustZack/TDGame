using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform spawnPoint;
    public GameObject enemyPrefab;
    float lastSpawn = 0;
    float spawnCooldown = 1;
    public Difficulty difficulty = Difficulty.Easy;
    public Queue<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        EnemyController.setWaypoints(this.waypoints);
        enemies = new Queue<GameObject>();
    }

    void SpawnEnemy() {
        this.lastSpawn = Time.time;
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.AddComponent<EnemyController>();
        enemies.Enqueue(enemy);
    }
    bool waitingForSpawnCooldown() {
        return this.lastSpawn + this.spawnCooldown < Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (this.waitingForSpawnCooldown()) this.SpawnEnemy();
    }
}
