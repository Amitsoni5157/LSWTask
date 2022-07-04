using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickScript : MonoBehaviour
{
    private bool isPicked = false;
    private bool isDropped = false;



    void Update()
    {
        // with this you can move your instatute object
        if (Input.GetMouseButton(0) && isDropped == false)
        {
            isPicked = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isPicked == true)
            {
                isDropped = true;
            }
        }
    }

    /// <summary>
    /// For destroy object 
    /// </summary>
    private void OnMouseDown()
    {
        if(isDropped = true && isPicked == true)
        {
            Debug.Log("Click!");
            Destroy(this.gameObject);
        }
        

        //_renderer.material.color =
          //  _renderer.material.color == Color.red ? Color.blue : Color.red;
    }



}
