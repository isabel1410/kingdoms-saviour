using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteMovement : MonoBehaviour
{
    public GameObject Arrows;
    public PlayerMovement playerMovement;
    public Transform[] leftRouteWaypoints;
    public Transform[] rightRouteWaypoints;
    public bool currentWayPointIsRoute;

    void Start()
    {
        //playerMovement = GetComponent<PlayerMovement>();
        currentWayPointIsRoute = false;
        Arrows.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMovement.Speed = 0;
            currentWayPointIsRoute = true;
            Debug.Log(currentWayPointIsRoute);
            Debug.Log("triggered");
            Arrows.SetActive(true);
        }
    }

    public void TakeLeftRoute()
    {
        if (currentWayPointIsRoute)
        {
            Arrows.SetActive(false);
            Debug.Log("Took the left route");
            playerMovement.Speed = 5; // Temporary solution!
        }
    }

    public void TakeRightRoute()
    {
        if (currentWayPointIsRoute)
        {
            Arrows.SetActive(false);
            Debug.Log("Took the right route");
            playerMovement.Speed = 5; // Temporary solution!
        }
    }
}
