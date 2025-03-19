using System.Collections.Generic;
using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float attackDistace = 1f;
    public float chaseDistance = 5f;
    public float minWaypointDistance = 0.1f;
    public List<Transform> waypoints = new List<Transform>();

    private int waypointIndex = 0;
    private Vector2 cursorPos;
    private Vector2 targetPosition;

    void Start()
    {
        // Set starting patrol waypoint
        UpdateWaypointTarget();
    }

    void Update()
    {
        // Get cursor position
        cursorPos = GetCursorPosition();

        // Attack if close enough
        if (Vector2.Distance(transform.position, cursorPos) < attackDistace)
        {
            Debug.Log("Attack");
        }
        // Chase if close enough, but not in attack range
        else if (Vector2.Distance(transform.position, cursorPos) < chaseDistance)
        {
            SetCursorTarget();
            Movement();
        }
        // Patrol when not in attack or chase range
        else
        {
            UpdateWaypointTarget();
            Movement();
        }
    }

    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void SetCursorTarget()
    {
        targetPosition = cursorPos;
    }

    void UpdateWaypointTarget()
    {
        targetPosition = waypoints[waypointIndex].position;
        // Change waypoint when close to current waypoint
        if (Vector2.Distance(transform.position, targetPosition) < minWaypointDistance)
        {
            waypointIndex += 1;
            // Reset waypointIndex when it gets too high
            if (waypointIndex > (waypoints.Count - 1))
            {
                waypointIndex = 0;
            }
        }
    }

    Vector3 GetCursorPosition()
    {
        Camera mainCam = Camera.main;
        return mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
