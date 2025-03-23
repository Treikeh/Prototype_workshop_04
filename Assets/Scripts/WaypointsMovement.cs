using System.Collections.Generic;
using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public List<Transform> waypoints = new List<Transform>();

    private float minDistance = 0.1f;
    private int waypointIndex = 0;
    private Vector2 targetPosition;

    void Start()
    {
        // Set starting patrol waypoint
        UpdateWaypointTarget();
    }

    void Update()
    {
        UpdateWaypointTarget();
        Movement();
    }

    void Movement()
    {
        // Move towards a waypoint
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void UpdateWaypointTarget()
    {
        targetPosition = waypoints[waypointIndex].position;
        // Change waypoint when close to current waypoint
        if (Vector2.Distance(transform.position, targetPosition) < minDistance)
        {
            waypointIndex += 1;
            // Reset waypointIndex when it gets too high
            if (waypointIndex > (waypoints.Count - 1))
            {
                waypointIndex = 0;
            }
        }
    }
}
