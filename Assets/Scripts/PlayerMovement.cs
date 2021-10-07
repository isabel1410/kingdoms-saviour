using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public List<Transform> Waypoints;// Until first choice, after left and right path joined
    public float Speed;
    public PlayerInputProcessor InputProcessor;

    private int currentWaypoint;// Default = 0, so Start function not needed
    private float previousSpeed;

    public void PauseMovement()
    {
        previousSpeed = Speed;
        Speed = 0;
    }

    public void ResumeMovement()
    {
        Speed = previousSpeed;
    }

    /// <summary>
    /// Insert <paramref name="waypoints"/> at the current waypoint index.
    /// </summary>
    /// <param name="waypoints"></param>
    public void InsertWaypoints(List<Transform> waypoints)
    {
        Waypoints.InsertRange(currentWaypoint + 1, waypoints);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveTowardsWaypoint();
    }

    /// <summary>
    /// Move on the path formed by <see cref="Waypoints"/>.
    /// </summary>
    private void MoveTowardsWaypoint()
    {
        if (currentWaypoint >= Waypoints.Count)
        {
            return;
        }

        // If close enough, get next waypoint
        Transform waypoint = Waypoints[currentWaypoint];
        if (Vector3.Distance(transform.position, waypoint.position) < 1.5)
        // if (transform.position == waypoint.position)
        {
            currentWaypoint++;
            MoveTowardsWaypoint();
            return;
        }

        // If not facing the next waypoint, gradually rotate
        float dot = Vector3.Dot((waypoint.transform.position - transform.position).normalized, transform.forward);
        if (dot < .9999)
        // If (Vector3.Dot(transform.forward, (waypoint.transform.position - transform.position).normalized) > 0.7f)
        {
            RotateTowardsWaypoint(waypoint);
            return;//comment this out to let the player move while turning
        }

        // If nearly facing the next waypoint, face waypoint (snap)
        // Prevents rotation while moving
        if (dot != 1)
        {
            transform.LookAt(waypoint);
        }

        // Move towards waypoint
        transform.position += Speed * Time.deltaTime * transform.forward;
    }

    /// <summary>
    /// Rotates gradually towards <paramref name="waypoint"/>.
    /// </summary>
    /// <param name="waypoint"></param>
    private void RotateTowardsWaypoint(Transform waypoint)
    {
        var targetRot = Quaternion.LookRotation(waypoint.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 1.5f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "WaveLoad":
                other.GetComponentInParent<WaveController>().Load();
                break;
            case "WaveActivate":
                other.GetComponentInParent<WaveController>().Activate();
                break;

        }
    }
}
