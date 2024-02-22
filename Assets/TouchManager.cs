using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    float timer = 0f;
    float MaxTapTime = 0.2f;
    bool hasMoved = false;
    Vector2 startPosition;
    Vector2 endPosition;
    List<Unique_Touch> touches = new List<Unique_Touch>();
    GestureActionScript actOn;
    bool isDragging = false;
    bool isRotating = false;
    // Start is called before the first frame update
    void Start()
    {
        actOn = FindAnyObjectByType<GestureActionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {

            foreach (Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Began)
                {
                    Unique_Touch unique_Touch = new Unique_Touch();
                    unique_Touch.touchID = t.fingerId;
                    touches.Add(unique_Touch);
                }

                Unique_Touch uniqueTouch = touches.Find(l => l.touchID == t.fingerId);
                if (uniqueTouch != null)
                {
                    uniqueTouch.UpdateTouch(t, actOn);
                }
            }

            List<Unique_Touch> activeTouches = touches.FindAll(t => t.touch.HasValue);

            if (activeTouches.Count == 1)
            {
                Unique_Touch touch1 = activeTouches[0];
                if (touch1.hasMoved)
                {
                    isRotating = false; 
                    isDragging = false; 
                    actOn.CameraLook(touch1);
                }
            }
            else if (activeTouches.Count == 2)
            {
                Unique_Touch touch1 = activeTouches[0];
                Unique_Touch touch2 = activeTouches[1];

                if (touch1.hasMoved && touch2.hasMoved)
                {
                    float angle = CalculateAngleBetweenTouches(touch1, touch2);

                    if (Mathf.Abs(angle) > 20)
                    {
                        isRotating = true;
                        isDragging = false; 
                        actOn.RotateCamera(touch1, touch2);
                    }
                    else
                    {
                        isDragging = true;
                        isRotating = false; 
                        actOn.DragCamera(touch1, touch2);
                    }
                }
            }

        }
        touches.RemoveAll(t => t.touch.HasValue && t.touch.Value.phase == TouchPhase.Ended);
    }

    float CalculateAngleBetweenTouches(Unique_Touch t1, Unique_Touch t2)
    {
        Vector2 t1StartPos = t1.startPosition;
        Vector2 t2StartPos = t2.startPosition;
        Vector2 t1CurrentPos = t1.touch.Value.position;
        Vector2 t2CurrrentPos = t2.touch.Value.position;

        Vector2 dirStart = (t2StartPos - t1StartPos).normalized;
        Vector2 dirCur = (t2CurrrentPos - t1CurrentPos).normalized;

        float startAngle = Mathf.Atan2(dirStart.y, dirStart.x) * Mathf.Rad2Deg;
        float curAngle = Mathf.Atan2(dirCur.y, dirCur.x) * Mathf.Rad2Deg;

        return curAngle - startAngle;
    }
}
