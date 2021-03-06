﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeSnapIn : MonoBehaviour
{
    public Transform local;
    public GameObject start;
    bool free = true;
    public AudioClip click;
    public AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    OVRHapticsClip buzz;

    private void Start()
    {
        buzz = new OVRHapticsClip(click);
    }

    private void OnTriggerEnter(Collider col)//other)
    {
        if ((col.CompareTag("Previous")) && free)
        {
            

            Transform other = col.gameObject.GetComponentInParent<Transform>();
            
            Vector3 pos = new Vector3(local.position.x   , local.position.y, local.position.z);
            //Vector3 ofc = new Vector3(-0.02f, 0f, 0f);
            other.transform.position = pos;//Vector3.MoveTowards(other.transform.position, pos, 2 * Time.deltaTime);
            //other.transform.parent.position = other.transform.position - other.transform.localPosition;
            //other.transform.localPosition = new Vector3(other.transform.localPosition.x, other.transform.localPosition.y, other.transform.localPosition.z);
            other.transform.rotation = local.rotation;
            //other.transform.rotation = local.rotation;
            //other.transform.parent = local.transform;

            other.transform.parent = local.transform;
            // col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            OVRHaptics.LeftChannel.Mix(buzz);
            OVRHaptics.RightChannel.Mix(buzz);
            free = false;
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(click, vol);

            start.GetComponent<codeList>().AddToList(col.gameObject);

            

        }
    }
}
