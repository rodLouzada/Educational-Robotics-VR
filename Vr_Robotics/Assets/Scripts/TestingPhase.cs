using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPhase : MonoBehaviour
{
    public GameObject gm;
    public GameObject wall;
    public GameObject btn_run;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("hand"))
        {
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
