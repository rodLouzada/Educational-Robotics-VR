using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hand : MonoBehaviour
{
    public PickupObject attachment = null;
    public bringNumbers attachment2 = null;
    public setValue attachment3 = null;
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
        bringNumbers b = rb.GetComponent<bringNumbers>();
        setValue y = rb.GetComponent<setValue>();




        if (p == null) { return; }

        float triggerValue;
        bool buttonXPress;
        bool buttonYPress;

        if (ct == OVRInput.Controller.LTouch)
        {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
            buttonXPress = OVRInput.Get(OVRInput.Button.Three);
            buttonYPress = OVRInput.Get(OVRInput.Button.Four);
            
            }
        else if (ct == OVRInput.Controller.RTouch)
        {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
            buttonXPress = OVRInput.Get(OVRInput.Button.One);
            buttonYPress = OVRInput.Get(OVRInput.Button.Two);
            }
        else {
            triggerValue = 0;
            buttonXPress = false;
            buttonYPress = false;
            }// OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger); }



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

        if ( buttonXPress)
            {
            attachment2 = b;

            attachment2.ShowNumbers();

            attachment2 = null;
            }

        if (buttonYPress)
            {
            attachment3 = y;

            attachment3.SetValues();

            attachment3 = null;
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
