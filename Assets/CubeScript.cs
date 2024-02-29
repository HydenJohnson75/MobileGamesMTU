using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeScript : MonoBehaviour, I_Interactable
{
    [SerializeField]
    Material material;

    public void ProcessDrag(Ray ray)
    {
        float distance = Vector3.Distance(ray.origin, transform.position);

        Vector3 newPosition = new Vector3(ray.GetPoint(distance).x, ray.GetPoint(distance).y, transform.position.z);
        transform.position = newPosition;
    }

    public void processTap()
    {
        this.GetComponent<Renderer>().material.color = Color.magenta;
    }

    public void Unselect()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
    }

    public void Scale(Vector3 scaleFactor)
    {
        transform.localScale += scaleFactor;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate(float angle)
    {
        transform.Rotate(Vector3.forward, angle);
    }
}
