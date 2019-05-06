using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSnap : MonoBehaviour
{
    public GameObject part;
    public GameObject invisiblePart;
    public AudioClip click;
    public AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

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
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(click, vol);
            //part.transform.position = this.gameObject.transform.position;
            //part.transform.rotation = this.gameObject.transform.rotation;
            }
    }


    // Update is called once per frame
    void Update()
    {
        
    }


}
