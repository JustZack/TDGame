using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public Camera Camera;
    public static GameObject PlacementLayer;
    public Transform[] waypoints;
    public Transform spawnPoint;
    public EnemyData enemyData;
    float lastSpawn = 0;
    float spawnCooldown = .1f;
    public Difficulty difficulty = Difficulty.Easy;
    public Queue<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        EnemyController.setWaypoints(this.waypoints);
        enemies = new Queue<GameObject>();
        this.CreatePlacementLayer();
    }

    void CreatePlacementLayer() {
        GameObject placementLayer = new GameObject(Tags.PlacementLayer);
        PlacementLayer placementScript = placementLayer.AddComponent<PlacementLayer>();
        BoxCollider2D placementCollider = placementLayer.AddComponent<BoxCollider2D>();

        if (this.Camera.orthographic) {
            float camHeight = this.Camera.orthographicSize * 2;
            float camWidth = camHeight * this.Camera.aspect;

            placementLayer.transform.position = this.Camera.transform.position;
            placementLayer.transform.localScale = new Vector3(camWidth, camHeight, 1);
            placementCollider.transform.position = this.Camera.transform.position;
            placementCollider.size = new Vector2(camWidth, camHeight);
        } else {
            throw new System.Exception("Provided camera should be orthographic.");
        }

        SpawnerButton.setPlacementLayer(placementScript);
    }

    void SpawnEnemy() {
        this.lastSpawn = Time.time;
        GameObject enemy = enemyData.Instantiate();
        enemy.transform.position = spawnPoint.position;
        enemy.transform.rotation = spawnPoint.rotation;
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
