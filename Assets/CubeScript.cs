using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour, I_Interactable
{
    [SerializeField]
    Material material;

    public void ProcessDrag(Vector2 endPosition)
    {
        transform.position = endPosition;
    }

    public void processTap()
    {
        this.GetComponent<Renderer>().material = material;
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
