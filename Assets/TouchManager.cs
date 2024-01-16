using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    float timer = 0f;
    float MaxTapTime = 0.2f;
    bool hasMoved = false;
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
                            break;
                        }
                    case TouchPhase.Moved:
                        {
                            hasMoved = true;
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

            //foreach (Touch t in Input.touches)
            //{
            //    
            //    if(t.phase == TouchPhase.Stationary && t.phase != TouchPhase.Moved)
            //    {
            //        if (timer <= 0 && t.phase == TouchPhase.Ended)
            //        { 
            //                print("Tap Working");
            //                timer = 1f;
            //        }
            //        else
            //        {
            //            timer -= Time.deltaTime;
            //        } 
            //    }
            //}
            //print(timer);
        }

    }
}
