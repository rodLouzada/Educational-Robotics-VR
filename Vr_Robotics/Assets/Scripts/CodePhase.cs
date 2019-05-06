using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePhase : MonoBehaviour
{
    public GameObject rhand;
    public GameObject lhand;
    public GameObject gm;
    public GameObject wall;
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
        if (col.CompareTag("hand")){
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(select, volHighRange);
            gm.GetComponent<GameManager>().initialSetup.SetActive(false);
            gm.GetComponent<GameManager>().guidedBuilding.SetActive(false);
            gm.GetComponent<GameManager>().codeBuilder.SetActive(true);
            gm.GetComponent<GameManager>().DisplayOnArm("Snap Code Blocks together to Program your car");
            wall.SetActive(false);
            }
        }

    // Update is called once per frame
    void Update()
        {

        }
    }
