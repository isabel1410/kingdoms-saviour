using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    void Awake()
    {
        //Cursor.visible = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rect = (RectTransform)transform;
        float x = Input.mousePosition.x / Screen.width;
        float y = Input.mousePosition.y / Screen.height;
        rect.anchorMin = new Vector2(x, y);
        rect.anchorMax = new Vector2(x, y);

        /*
        Vector3 mouseWithDistance = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2f);
        Vector3 followCursor = Camera.main.ScreenToWorldPoint(mouseWithDistance);
        followCursor.z = 0;
        transform.position = followCursor; //s new Vector2(followCursor.x, followCursor.y);
        */
        Debug.Log(transform.position);
    }
}
