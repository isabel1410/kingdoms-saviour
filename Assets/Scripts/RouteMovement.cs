using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteMovement : MonoBehaviour
{
    public GameObject Arrows;
    public bool currentWayPointIsRoute;

    void Start()
    {
        currentWayPointIsRoute = false;
        Arrows.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            currentWayPointIsRoute = true;
            Debug.Log(currentWayPointIsRoute);
            Debug.Log("triggered");
            Arrows.SetActive(true);
        }
    }
}
