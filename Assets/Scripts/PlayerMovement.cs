using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PauseMovementEvent : UnityEngine.Events.UnityEvent { }

public class PlayerMovement : MonoBehaviour
{
    public List<Transform> Waypoints;// Until first choice, after left and right path joined
    public float MovementSpeed;
    public float RotationSpeed;
    //public PlayerInputProcessor InputProcessor;

    private int currentWaypoint;// Default = 0, so Start function not needed
    private float previousMovementSpeed;
    private float previousRotationSpeed;

    public void ToggleMovement(bool paused)
    {
        if (paused)
        {
            PauseMovement();
        }
        else
        {
            ResumeMovement();
        }

    }

    public void PauseMovement()
    {
        previousMovementSpeed = MovementSpeed;
        previousRotationSpeed = RotationSpeed;
        MovementSpeed = RotationSpeed = 0;
    }

    public void ResumeMovement()
    {
        MovementSpeed = previousMovementSpeed;
        RotationSpeed = previousRotationSpeed;
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
        if (Vector3.Distance(transform.position, waypoint.position) < 0.1)
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
        transform.position += Time.deltaTime * transform.forward * MovementSpeed;
    }

    /// <summary>
    /// Rotates gradually towards <paramref name="waypoint"/>.
    /// </summary>
    /// <param name="waypoint"></param>
    private void RotateTowardsWaypoint(Transform waypoint)
    {
        var targetRot = Quaternion.LookRotation(waypoint.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 1.5f * Time.deltaTime * RotationSpeed);
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
