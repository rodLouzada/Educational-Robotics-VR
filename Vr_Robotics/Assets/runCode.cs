using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runCode : MonoBehaviour
    {
    public codeList cl;
    public AudioClip select;
    public AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    private void OnTriggerEnter(Collider col)
        {
        if (col.CompareTag("hand"))
            {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(select, volHighRange);
            StartCoroutine(cl.runCode(cl._main_block_list));
            this.gameObject.SetActive(false);
            }
        }
    }
