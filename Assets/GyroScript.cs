using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroScript : MonoBehaviour
{

    float speed = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateObject();
    }


    private void RotateObject()
    {
        Vector3 tilt = Input.acceleration;
        Quaternion target = Quaternion.Euler(-tilt.y * speed * 90, tilt.x * speed * 90, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * speed);
    }

}
