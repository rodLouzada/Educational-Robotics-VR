using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBlock : MonoBehaviour
{
    public Transform holder;
    public Rigidbody rb;
    private Vector3 positionHolder;
    private Quaternion rotationHolder;
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
        rb.useGravity = false;
        rb.maxAngularVelocity = Mathf.Infinity;
        holder = t;

    }

    public void released(Transform t, Vector3 vel)
    {
        if (t == holder)
        {
            holder = null;
        }
    }

    public void snapped()
    {
        holder = null;
        rb.useGravity = false;
        rb.isKinematic = true;
    }
}