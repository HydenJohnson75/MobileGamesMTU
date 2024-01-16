using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureActionScript : MonoBehaviour
{
    [SerializeField]
    Material m_Material;
    internal void TapAt(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.gameObject.name);
            
            I_Interactable objectHit = hit.collider.GetComponent<I_Interactable>();
            if (objectHit != null)
            {
                objectHit.processTap();
            }
                
          

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
}
