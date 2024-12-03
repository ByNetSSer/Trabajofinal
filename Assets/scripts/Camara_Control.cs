using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Control : MonoBehaviour
{
    public GameObject objetivo;
    public float minposition;
    public float maxposition;
    Vector3 vectorZero = new Vector3(0,0,0);
    public float speedcamera;
    // Start is calledbefore the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objetivo != null)
        {
            
            float positionX = Mathf.Clamp(objetivo.transform.position.x, minposition, maxposition);
            transform.position = new Vector3(positionX, objetivo.transform.position.y, -20);
            
            //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(objetivo.transform.position.x,objetivo.transform.position.y,-10), ref vectorZero, speedcamera);
            
        }
    }
}
