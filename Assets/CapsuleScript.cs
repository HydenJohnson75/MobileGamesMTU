using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScript : MonoBehaviour, I_Interactable
{
    public void ProcessDrag(Ray ray)
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Plane")
            {
                transform.position =  new Vector3(hit.point.x, hit.point.y, transform.position.z);
            }
        }
    }

    public void processTap()
    {
        this.GetComponent<Renderer>().material.color = Color.cyan;
    }

    public void Unselect()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
