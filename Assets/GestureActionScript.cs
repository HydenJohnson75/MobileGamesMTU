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

    internal void FingerRotate(Unique_Touch t1, Unique_Touch t2)
    {
        if (currentlySelectedObj == null)
        {
            if (t1 != null && t2 != null)
            {
                Vector2 t1StartPos = t1.startPosition;
                Vector2 t2StartPos = t2.startPosition;
                Vector2 t1CurPos = t1.touch.Value.position;
                Vector2 t2CurPos = t2.touch.Value.position;

                Vector2 dirStart = (t2StartPos - t1StartPos).normalized;
                Vector2 dirCur = (t2CurPos - t1CurPos).normalized;


                float startAngle = Mathf.Atan2(dirStart.y, dirStart.x) * Mathf.Rad2Deg;
                float curAngle = Mathf.Atan2(dirCur.y, dirCur.x) * Mathf.Rad2Deg;

                float rotationAngle = curAngle - startAngle;

                Quaternion targetRotation = Quaternion.Euler(0, 0, startAngle + rotationAngle);

                float rotationSpeed = 0.5f;
                Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
        else
        {
            Vector2 t1StartPos = t1.startPosition;
            Vector2 t2StartPos = t2.startPosition;
            Vector2 t1CurPos = t1.touch.Value.position;
            Vector2 t2CurPos = t2.touch.Value.position;

            Vector2 dirStart = (t2StartPos - t1StartPos).normalized;
            Vector2 dirCur = (t2CurPos - t1CurPos).normalized;

            float startAngle = Mathf.Atan2(dirStart.y, dirStart.x) * Mathf.Rad2Deg;
            float curAngle = Mathf.Atan2(dirCur.y, dirCur.x) * Mathf.Rad2Deg;

            float rotationAngle = curAngle - startAngle;

            currentlySelectedObj.Rotate(rotationAngle);
        }


    }

    internal void FingerMovedDistance(Unique_Touch t1, Unique_Touch t2)
    {
        if (currentlySelectedObj == null)
        {
            // Zoom the camera
            ZoomCamera(t1, t2);
        }
        else
        {
            // Scale the object
            ScaleObject(t1, t2);
        }
    }

    void ZoomCamera(Unique_Touch t1, Unique_Touch t2)
    {
        float distance = TouchManager.CalculateDistanceBetweenTouches(t1, t2);
        float startDistance = Vector2.Distance(t1.startPosition, t2.startPosition);

        float zoomFactor = 0.00001f * distance;

        if (distance > startDistance)
        {
            Camera.main.transform.position += Camera.main.transform.forward * zoomFactor;
        }
        else
        {
            Camera.main.transform.position -= Camera.main.transform.forward * zoomFactor;
        }
        // Adjust zoom factor based on the distance between touches
         // Adjust as needed

        // Apply zoom
        
    }

    void ScaleObject(Unique_Touch t1, Unique_Touch t2)
    {
        float distance = TouchManager.CalculateDistanceBetweenTouches(t1, t2);
        float startDistance = Vector2.Distance(t1.startPosition, t2.startPosition);
        // Adjust scale factor based on the distance between touches
        float scaleFactor = 0.00001f * distance; // Adjust as needed

        if(t1.hasMoved && t2.hasMoved)
        {
            if (distance > startDistance)
            {
                currentlySelectedObj.Scale(new Vector3(scaleFactor, scaleFactor, scaleFactor));
            }
            else
            {
                currentlySelectedObj.Scale(new Vector3(-scaleFactor, -scaleFactor, -scaleFactor));
            }
        }


        // Apply scale to the object
    }

    internal void DragCamera(Unique_Touch t1, Unique_Touch t2)
    {
        if(currentlySelectedObj == null)
        {
            if (t1 != null && t2 != null)
            {
                Vector2 t1StartPos = t1.startPosition;
                Vector2 t2StartPos = t2.startPosition;
                Vector2 t1CurrentPos = t1.touch.Value.position;
                Vector2 t2CurrrentPos = t2.touch.Value.position;

                Vector2 delta1 = t1CurrentPos - t1StartPos;
                Vector2 delta2 = t2CurrrentPos - t2StartPos;

                Vector2 movement = (delta1 + delta2) * 0.01f; 

                float moveX = movement.x * Time.deltaTime;
                float moveY = movement.y * Time.deltaTime;

                Camera.main.transform.Translate(new Vector3(moveX, moveY, 0));
            }
        }
    }

    internal void CameraLook(Unique_Touch t1)
    {
        if(currentlySelectedObj == null)
        {
            if (t1 != null && t1.hasMoved)
            {
                float sensitivityY = 0.5f; 

                Vector2 currentPos = t1.touch.Value.position;
                Vector2 delta = currentPos - t1.previousPosition;


                float rotationY = delta.y * sensitivityY; 

                Transform cameraTransform = Camera.main.transform;
                cameraTransform.Rotate(cameraTransform.right, rotationY); 

                t1.previousPosition = currentPos;
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
