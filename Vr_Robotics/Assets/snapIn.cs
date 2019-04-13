using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapIn : MonoBehaviour
{
    public Transform local;
    bool free = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)//other)
    {
        if (col.CompareTag("Block") && free)
        {
            Rigidbody other = col.gameObject.GetComponent<Rigidbody>();
            other.GetComponent<PickupObject>().snapped();
            Vector3 pos = new Vector3(local.position.x, local.position.y, local.position.z);
            
            other.transform.position = pos;//Vector3.MoveTowards(other.transform.position, pos, 2 * Time.deltaTime);
            other.transform.parent = local.transform;

            other.transform.localRotation = local.localRotation;
            free = false;
        }
    }
}
