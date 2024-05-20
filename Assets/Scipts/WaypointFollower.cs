using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int currentWaypointIndex;

    [SerializeField] private float speed = 2f;

    private void Awake() {
        currentWaypointIndex = 0;
    }

    private void Update() {
        if (Vector2.Distance(waypoints[currentWaypointIndex].position, transform.position) <= 0f) {
            currentWaypointIndex = (currentWaypointIndex != waypoints.Length - 1) ? currentWaypointIndex + 1 : 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
    }
}
