using System.Collections.Generic;
using UnityEngine;

public class RouteMovement : MonoBehaviour
{
    public GameObject Arrows;
    public Canvas crossHair;
    public PlayerMovement playerMovement;
    public List<Transform> leftRouteWaypoints;
    public List<Transform> rightRouteWaypoints;
    public ItemController itemController;

    // Start is called before the first frame update
    private void Start()
    {
        //playerMovement = GetComponent<PlayerMovement>();
        Arrows.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Show arrows when player enters boxcollider
        if (other.gameObject.CompareTag("Player"))
        {
            itemController.canUseWeapon = false;
            Cursor.visible = true;
            playerMovement.PauseMovement();
            Arrows.SetActive(true);
            crossHair.enabled = false;

            Debug.Log("Route choice triggered");
        }
    }

    /// <summary>
    /// Inserts left route waypoints into main waypoint list.
    /// Resumes player movement.
    /// </summary>
    public void TakeLeftRoute()
    {
        itemController.canUseWeapon = true;
        Arrows.SetActive(false);
        Cursor.visible = false;
        crossHair.enabled = true;
        playerMovement.InsertWaypoints(leftRouteWaypoints);
        playerMovement.ResumeMovement();
        Debug.Log("Took the left route");
    }

    /// <summary>
    /// Inserts right route waypoints into main waypoint list.
    /// Resumes player movement.
    /// </summary>
    public void TakeRightRoute()
    {
        itemController.canUseWeapon = true;
        Arrows.SetActive(false);
        Cursor.visible = false;
        crossHair.enabled = true;
        playerMovement.InsertWaypoints(rightRouteWaypoints);
        playerMovement.ResumeMovement();
        Debug.Log("Took the right route");
    }
}
