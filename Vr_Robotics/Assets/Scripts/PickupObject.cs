using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Transform holder;
    public Rigidbody rb;
    private Vector3 positionHolder;
    private Quaternion rotationHolder;
    private bool saveGravity = false;
    private float saveMaxAngularVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (holder != null)
        {
            
            
                
                Vector3 desiredPos = holder.localToWorldMatrix.MultiplyPoint(positionHolder);
                Vector3 currentPos = this.transform.position;
                Quaternion desiredRotation = holder.rotation * rotationHolder;
                Quaternion currentRotation = this.transform.rotation;
                rb.velocity = (desiredPos - currentPos) / Time.fixedDeltaTime;

                Quaternion offsetRotation = desiredRotation * Quaternion.Inverse(currentRotation);
                float angle; Vector3 axis;
                offsetRotation.ToAngleAxis(out angle, out axis);
                Vector3 rotationDiff = angle * Mathf.Deg2Rad * axis;
                rb.angularVelocity = rotationDiff / Time.fixedDeltaTime;
                
        }
        else
            {
            if (this.tag == "Code")
                {
                rb.velocity = new Vector3(0, 0, 0);
                }
            }
    }

    public void pickedUp(Transform t)
    {
        
        Debug.Log("I MADE IT HERE!");
        if (holder != null)
        {
            return;
        }
        positionHolder = t.worldToLocalMatrix.MultiplyPoint(this.transform.position);
        rotationHolder = Quaternion.Inverse(t.rotation) * this.transform.rotation;
        saveGravity = rb.useGravity;
        rb.useGravity = false;
        saveMaxAngularVelocity = rb.maxAngularVelocity;
        rb.maxAngularVelocity = Mathf.Infinity;
        holder = t;

    }

    public void released(Transform t, Vector3 vel)
    {
        if (t == holder)
        {
            if (this.tag == "Code")
                {
                rb.velocity = new Vector3(0, 0, 0);
                rb.maxAngularVelocity = 0f;
                rb.useGravity = false;

                holder = null;
                }
            else
                {
                rb.useGravity = saveGravity;
                rb.maxAngularVelocity = saveMaxAngularVelocity;
                rb.velocity = vel;
                holder = null;
                }
        }
    }

    public void snapped()
    {
        holder = null;
        rb.useGravity = false;
        rb.isKinematic = true;
    }
}