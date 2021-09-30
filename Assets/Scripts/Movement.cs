using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] Waypoints;
    public float Speed;
    public int currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsWaypoint();
    }

    private void MoveTowardsWaypoint()
    {
        if (currentWaypoint >= Waypoints.Length)
        {
            return;
        }

        //If close enough, get next waypoint
        Transform waypoint = Waypoints[currentWaypoint];
        if (Vector3.Distance(transform.position, waypoint.position) < 1.5)
        //if (transform.position == waypoint.position)
        {
            currentWaypoint++;
            MoveTowardsWaypoint();
            return;
        }

        //If not facing the next waypoint, gradually rotate
        float dot = Vector3.Dot((waypoint.transform.position - transform.position).normalized, transform.forward);
        if (dot < .9999)
        //if (Vector3.Dot(transform.forward, (waypoint.transform.position - transform.position).normalized) > 0.7f)
        {
            RotateTowardsWaypoint(waypoint);
            return;//comment this out to let the player move while turning
        }

        //If nearly facing the next waypoint, face waypoint (snap)
        //Prevents rotation while moving
        if (dot != 1)
        {
            transform.LookAt(waypoint);
        }

        //Move towards waypoint
        transform.position += Speed * Time.deltaTime * transform.forward;
    }

    private void RotateTowardsWaypoint(Transform waypoint)
    {
        var targetRot = Quaternion.LookRotation(waypoint.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, .01f);/*
        return;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(waypoint.position), .1f);
        return;
        Quaternion rot = Quaternion.FromToRotation(transform.position, waypoint.position);
        transform.rotation = rot;
        gameObject.transform.LookAt(waypoint);*/
    }
}
