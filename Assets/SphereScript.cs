using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour, I_Interactable
{
    public void ProcessDrag(Vector2 endPosition)
    {
        throw new System.NotImplementedException();
    }

    public void processTap()
    {
        transform.position += Vector3.up * 10 * Time.deltaTime;
    }

    public void Unselect()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
