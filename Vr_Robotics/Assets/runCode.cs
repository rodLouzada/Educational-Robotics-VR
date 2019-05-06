using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runCode : MonoBehaviour
    {
    public codeList cl;

    private void OnTriggerEnter(Collider col)
        {
        if (col.CompareTag("hand"))
            {
            
            StartCoroutine(cl.runCode(cl._main_block_list));
            }
        }
    }
