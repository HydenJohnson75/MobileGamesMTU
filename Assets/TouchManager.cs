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
    GestureActionScript actOn;
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
                switch (t.phase)
                {
                    case TouchPhase.Began:
                        {
                            timer = 0f;
                            hasMoved = false;
                            startPosition = t.position;
                            break;
                        }
                    case TouchPhase.Moved:
                        {
                            Debug.DrawRay(Camera.main.ScreenPointToRay(t.position).origin, Camera.main.ScreenPointToRay(t.position).direction * 10);
                            hasMoved = true;

                            actOn.DragAt(t.position);
                            break;
                        }
                    case TouchPhase.Stationary:
                        {
                            timer += Time.deltaTime;
                            break;
                        }
                    case TouchPhase.Ended:
                        {

                            if ((timer < MaxTapTime) && !hasMoved)
                            {
                                actOn.TapAt(t.position);
                            }
                            break;
                        }
                }
            }

        }

    }
}
