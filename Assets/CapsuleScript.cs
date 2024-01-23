using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScript : MonoBehaviour, I_Interactable
{
    public void ProcessDrag(Vector2 endPosition)
    {
        throw new System.NotImplementedException();
    }

    public void processTap()
    {
        transform.localScale += new Vector3(1, 1, 1);
    }

    public void Unselect()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
