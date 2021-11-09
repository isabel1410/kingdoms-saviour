using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    public Canvas parentCanvas;
    void Awake()
    {
        Cursor.visible = false;
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    RectTransform rect = (RectTransform)transform;
    //    float x = Input.mousePosition.x / Screen.width;
    //    float y = Input.mousePosition.y / Screen.height;
    //    rect.anchorMin = new Vector2(x, y);
    //    rect.anchorMax = new Vector2(x, y);
    //    Debug.Log(transform.position);
    //}

    public void Start()
    {
        Vector2 pos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform, Input.mousePosition,
            parentCanvas.worldCamera,
            out pos);
    }

    public void Update()
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition, parentCanvas.worldCamera,
            out movePos);

        transform.position = parentCanvas.transform.TransformPoint(movePos);
    }
}
