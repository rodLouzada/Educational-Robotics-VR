using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapAttachment : MonoBehaviour
{
    public Transform local;
    bool free = true;

    private void OnTriggerEnter(Collider col)//other)
    {


        if ((col.CompareTag("Previous")) && free)
        {
            /*Rigidbody other = col.gameObject.GetComponent<Rigidbody>();
            Transform parent = other.gameObject.GetComponentInParent<Transform>(); */

            Transform other = col.gameObject.GetComponentInParent<Transform>();

            //parent.GetComponent<PickupObject>().snapped();
            Vector3 pos = new Vector3(local.position.x, local.position.y, local.position.z);

            other.transform.position = pos;//Vector3.MoveTowards(other.transform.position, pos, 2 * Time.deltaTime);
            other.transform.parent.position = other.transform.position - other.transform.localPosition;

            other.transform.localRotation = local.localRotation;
            other.transform.parent = local.transform;


            free = false;


        }
    }
}
