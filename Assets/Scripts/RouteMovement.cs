using System.Collections.Generic;
using UnityEngine;

public class RouteMovement : MonoBehaviour
{
    public GameObject Arrows;
    public PlayerMovement playerMovement;
    public List<Transform> leftRouteWaypoints;
    public List<Transform> rightRouteWaypoints;
    public bool currentWayPointIsRoute;// Why?

    // Start is called before the first frame update
    private void Start()
    {
        //playerMovement = GetComponent<PlayerMovement>();
        currentWayPointIsRoute = false;
        Arrows.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Show arrows when player enters boxcollider
        if (other.gameObject.CompareTag("Player"))
        {
            playerMovement.PauseMovement();
            currentWayPointIsRoute = true;
            Arrows.SetActive(true);

            Debug.Log(currentWayPointIsRoute);
            Debug.Log("Route choice triggered");
        }
    }

    /// <summary>
    /// Inserts left route waypoints into main waypoint list.
    /// Resumes player movement.
    /// </summary>
    public void TakeLeftRoute()
    {
        if (currentWayPointIsRoute)
        {
            Arrows.SetActive(false);

            playerMovement.InsertWaypoints(leftRouteWaypoints);
            playerMovement.ResumeMovement();
            Debug.Log("Took the left route");
        }
    }

    /// <summary>
    /// Inserts right route waypoints into main waypoint list.
    /// Resumes player movement.
    /// </summary>
    public void TakeRightRoute()
    {
        if (currentWayPointIsRoute)
        {
            Arrows.SetActive(false);

            playerMovement.InsertWaypoints(rightRouteWaypoints);
            playerMovement.ResumeMovement();
            Debug.Log("Took the right route");
        }
    }
}
