using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] Waypoints;
    public float Speed;
    private int currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveTowardsWaypoint();
    }

    private void MoveTowardsWaypoint()
    {
        if (currentWaypoint >= Waypoints.Length)
        {
            return;
        }

        Transform waypoint = Waypoints[currentWaypoint];
        if (Vector3.Distance(transform.position, waypoint.position) < 1.5)
        //if (transform.position == waypoint.position)
        {
            currentWaypoint++;
            MoveTowardsWaypoint();
            return;
        }

        if (true)
        {
            RotateTowardsWaypoint(waypoint);
        }
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    private void RotateTowardsWaypoint(Transform transform)
    {
        
    }
}
