using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
            Debug.Log(hit.collider);
            print(hit.collider.gameObject.name);
            
            I_Interactable objectHit = hit.collider.GetComponent<I_Interactable>();
            if (objectHit != null)
            {
                if(currentlySelectedObj != null)
                {
                    currentlySelectedObj.Unselect();
                    currentlySelectedObj = null;
                }
                else
                {
                    currentlySelectedObj = objectHit;


                    objectHit.processTap();        
                }
                
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
            Ray ray = Camera.main.ScreenPointToRay(endPosition);

            currentlySelectedObj.ProcessDrag(ray);
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentlySelectedObj);
    }
}
