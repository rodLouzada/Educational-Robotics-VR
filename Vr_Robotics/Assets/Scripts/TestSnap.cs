using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSnap : MonoBehaviour
{
    public GameObject moveFrom;

    // Start is called before the first frame update
    void Start()
    {
        moveFrom.transform.position = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
