using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureActionScript : MonoBehaviour
{
    [SerializeField]
    Material m_Material;

    I_Interactable currentlySelectedObj;
    internal void TapAt(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.gameObject.name);
            
            I_Interactable objectHit = hit.collider.GetComponent<I_Interactable>();
            if (objectHit != null)
            {
                if(currentlySelectedObj != null)
                {
                    currentlySelectedObj.Unselect();
              
                }
                currentlySelectedObj = objectHit;

                objectHit.processTap();
            }
            else
            {
                if(currentlySelectedObj != null)
                {
                    currentlySelectedObj.Unselect();
                    currentlySelectedObj= null;
                }
            } 
          
        }
        else
        {
            if (currentlySelectedObj != null)
            {
                currentlySelectedObj.Unselect();
                currentlySelectedObj = null;
            }
        }


    }

    internal void DragAt(Vector2 endPosition)
    {
        //Debug.Log("Start: " + startPosition +  "    End: " + endPosition);
        if(currentlySelectedObj != null)
        {
            currentlySelectedObj.ProcessDrag(endPosition);
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
