using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HouseItem : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public GameObject ItemObject;

    // delegate ()
    public delegate void ItemClick(GameObject obj);

    //event  
    public static event ItemClick Click;

    private bool isItemSelected = false;
  


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click Down On Item");
        if (isItemSelected == false)
        {
            isItemSelected = true;
            OnButtonClick();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isItemSelected = false;
    }
    public void OnButtonClick()
    {
        //call the event
        Click(ItemObject);
    }

  
}
