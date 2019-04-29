using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSnap : MonoBehaviour
{
    public GameObject part;
    public GameObject invisiblePart;

    // Start is called before the first frame update
    void Start()
    {
        invisiblePart.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.Equals(part))
        {
            part.SetActive(false);
            invisiblePart.SetActive(true);
            //part.transform.position = this.gameObject.transform.position;
            //part.transform.rotation = this.gameObject.transform.rotation;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }


}
