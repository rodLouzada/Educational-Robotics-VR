using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeSnapIn : MonoBehaviour
{
    public Transform local;
    public GameObject start;
    bool free = true;

    private void Start()
    {
        start = GameObject.Find("Start");
    }

    private void OnTriggerEnter(Collider col)//other)
    {
        if ((col.CompareTag("Previous")) && free)
        {
            /*Rigidbody other = col.gameObject.GetComponent<Rigidbody>();
            Transform parent = other.gameObject.GetComponentInParent<Transform>(); */

            Transform other = col.gameObject.GetComponentInParent<Transform>();

            //parent.GetComponent<PickupObject>().snapped();
            Vector3 pos = new Vector3(local.position.x - 0.02f, local.position.y, local.position.z);
            //Vector3 ofc = new Vector3(-0.02f, 0f, 0f);
            other.transform.position = pos;//Vector3.MoveTowards(other.transform.position, pos, 2 * Time.deltaTime);
            other.transform.parent.position = other.transform.position - other.transform.localPosition;
            
            other.transform.localRotation = local.localRotation;
            other.transform.parent = local.transform;

           
            free = false;

            start.GetComponent<codeList>().AddToList(col.gameObject);

            

        }
    }
}
