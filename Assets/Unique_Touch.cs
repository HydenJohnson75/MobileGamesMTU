using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Unique_Touch
{

    internal Touch? touch;
    private float timer;
    internal float movementTimer;
    internal float maxMovementTimer = 1f;
    private float MaxTapTime = 0.3f;
    internal Vector2 startPosition;
    internal Vector2 previousPosition;
    internal Vector2 currentPosition;
    internal bool hasMoved;
    private GestureActionScript actOn;
    internal int touchID { get; set; }
    // Start is called before the first frame update



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTouch(Touch t, GestureActionScript act_On)
    {
        touch = t;

        switch (touch.Value.phase)
        {
            case TouchPhase.Began:
                timer = 0f;
                startPosition = touch.Value.position;
                hasMoved = false;
                break;

            case TouchPhase.Moved:
                Debug.DrawRay(Camera.main.ScreenPointToRay(touch.Value.position).origin, Camera.main.ScreenPointToRay(touch.Value.position).direction * 10);
                hasMoved = true;
                currentPosition = touch.Value.position;
                act_On.DragAt(touch.Value.position);
                break;

            case TouchPhase.Stationary:
                timer += Time.deltaTime;
                currentPosition = touch.Value.position;
                hasMoved = false;
                break;

            case TouchPhase.Ended:
                if (!hasMoved && timer < MaxTapTime)
                {
                    act_On.TapAt(touch.Value.position);
                    Debug.Log("Tap Detected");
                }
                break;
        }
    }
}
