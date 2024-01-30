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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {

            foreach (Touch t in Input.touches)
            {

            }

        }

    }
}
