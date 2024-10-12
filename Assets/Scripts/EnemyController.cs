using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int Health;
    int Hits = 0;
    int currentWaypointIndex = 0;
    float speed = 5f;
    static Transform[] waypoints;
    public static void setWaypoints(Transform[] waypoints) {
        EnemyController.waypoints = waypoints;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.Health = 50;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the current waypoint
        Transform targetWaypoint = EnemyController.waypoints[this.currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // Check if enemy has reached the waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;

            // Loop back to first waypoint if the enemy reaches the last waypoint
            if (currentWaypointIndex >= EnemyController.waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}
