using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    public Camera Camera;

    public void OnMouseDown()
    {
        Vector3 mouseposition = Mouse.current.position.ReadValue();
        Ray ray = Camera.ScreenPointToRay(mouseposition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.name.StartsWith("Orc"))
            {
                // the object identified by hit.transform was clicked
                // do whatever you want
                gameObject.SetActive(false);
            }
        }
        Debug.Log(hit.collider.name);
    }
}
