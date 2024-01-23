using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour, I_Interactable
{
    Rigidbody rb;

    public void ProcessDrag(Ray ray)
    {
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<Terrain>())
            {
                transform.position = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
            }
        }
    }

    public void processTap()
    {
        this.GetComponent<Renderer>().material.color =  Color.green;
        rb.isKinematic = true;
    }

    public void Unselect()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
        rb.isKinematic = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
