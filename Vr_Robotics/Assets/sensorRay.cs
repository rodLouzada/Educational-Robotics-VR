using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensorRay : MonoBehaviour
{
    public float distance;
    public bool isHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) *distance, out hit, Mathf.Infinity))
            {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
           // Debug.Log("Did Hit");
            isHit = true;
            }
        else
            {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distance, Color.white);
           // Debug.Log("Did not Hit");
            isHit = false;
            }

        }

   
}
