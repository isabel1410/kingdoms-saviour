using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Outline;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log(name + " shown");

        foreach (Transform child in transform)
        {
            if (child != this)
            {
                child.gameObject.SetActive(true);
            }
        }
        //enabled = true;
        //gameObject.SetActive(true);
        //GetComponentsInChildren<Renderer>().ToList().ForEach(renderer => renderer.enabled = true);
        //GetComponent<Renderer>().enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log(name + " hidden");

        foreach (Transform child in transform)
        {
            if (child != this)
            {
                child.gameObject.SetActive(false);
            }
        }
        //enabled = false;
        //gameObject.SetActive(false);
        //GetComponentsInChildren<Renderer>().ToList().ForEach(renderer => renderer.enabled = false);
        //GetComponent<Renderer>().enabled = true;
    }
}
