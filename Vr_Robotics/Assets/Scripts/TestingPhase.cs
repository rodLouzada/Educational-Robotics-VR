using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPhase : MonoBehaviour
{
    public GameObject gm;
    public GameObject wall;
    public GameObject btn_run;

    public AudioClip select;
    public AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("hand"))
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(select, volHighRange);
            gm.GetComponent<GameManager>().initialSetup.SetActive(false);           
            gm.GetComponent<GameManager>().codeBuilder.SetActive(false);
            gm.GetComponent<GameManager>().guidedBuilding.SetActive(true);
            wall.SetActive(true);
            btn_run.SetActive(true);
            gm.GetComponent<GameManager>().DisplayOnArm("Great Coding");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
