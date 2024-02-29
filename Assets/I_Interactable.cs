using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface I_Interactable 
{
    void processTap();

    void ProcessDrag(Ray ray);
    void Unselect();

    public void Scale(Vector3 scaleFactor);

    public void Rotate(float angle);

}
