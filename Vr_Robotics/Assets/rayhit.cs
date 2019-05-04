using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayhit : MonoBehaviour
{
    public float distanceHit;
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        
        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            distanceHit = hit.distance;
            }
        else
            {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            }
        }
}
