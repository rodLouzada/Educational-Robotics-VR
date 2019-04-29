using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hand : MonoBehaviour
{
    public PickupObject attachment = null;
    public OVRInput.Controller ct;

    public bool dissapear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attachment == null)
        {


            MeshRenderer[] meshHand = GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer m in meshHand)
            {
                m.enabled = true;
            }

        }
    }

    public float pickTriggerTrashHold;
    public float releaseTriggerTrashHold;

    private void OnTriggerStay(Collider c)
    {
        Rigidbody rb = c.attachedRigidbody;
        if (rb == null) { return; }

        PickupObject p = rb.GetComponent<PickupObject>();

        

        if (p == null) { return; }

        float triggerValue;

        if (ct == OVRInput.Controller.LTouch)
        {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        }
        else if (ct == OVRInput.Controller.RTouch)
        {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        }
        else { triggerValue = 0; }// OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger); }

        if (attachment == null && triggerValue > pickTriggerTrashHold)
        {
            attachment = p;

            attachment.pickedUp(this.transform);
            MeshRenderer[] meshHand =  GetComponentsInChildren<MeshRenderer>();

            foreach(MeshRenderer m in meshHand)
            {
                m.enabled = false;
            }



        }


        if (attachment != null && triggerValue < releaseTriggerTrashHold)
        {
            attachment.released(this.transform, OVRInput.GetLocalControllerVelocity(ct));

            attachment = null;

            MeshRenderer[] meshHand = GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer m in meshHand)
            {
                m.enabled = true;
            }

        }

        

        




    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("rst") )
    //    {
    //        Scene scene = SceneManager.GetActiveScene();
    //        SceneManager.LoadScene(scene.name);

    //    }
    //}


}
