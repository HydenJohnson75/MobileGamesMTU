using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Unique_Touch : MonoBehaviour
{

    private Touch? touch;
    private float timer;
    private float MaxTapTime;
    private Vector2 startPosition;
    private bool hasMoved;
    private GestureActionScript actOn;
    internal int touchID { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        actOn = FindAnyObjectByType<GestureActionScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if(touch != null)
        {
            
            switch (touch.Value.phase)
            {
                case TouchPhase.Began:
                    {
                        timer = 0f;
                        hasMoved = false;
                        startPosition = touch.Value.position;
                        break;
                    }
                case TouchPhase.Moved:
                    {
                        Debug.DrawRay(Camera.main.ScreenPointToRay(touch.Value.position).origin, Camera.main.ScreenPointToRay(touch.Value.position).direction * 10);
                        hasMoved = true;

                        //actOn.DragAt(touch.Value.position);
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
                            //actOn.TapAt(touch.Value.position);
                        }
                        break;
                    }
            }
        }

        
    }
}
