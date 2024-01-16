using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour, I_Interactable
{
    [SerializeField]
    Material material;
    public void processTap()
    {
        this.GetComponent<Renderer>().material = material;
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
