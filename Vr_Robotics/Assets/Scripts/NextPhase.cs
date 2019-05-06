using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPhase : MonoBehaviour
{
    public GameObject rhand;
    public GameObject lhand;
    public GameObject gm;
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        //if(col.gameObject.Equals(rhand) || col.gameObject.Equals(lhand))
        //{           
            gm.GetComponent<GameManager>().initialSetup.SetActive(false);
            gm.GetComponent<GameManager>().codeBuilder.SetActive(false);
            gm.GetComponent<GameManager>().guidedBuilding.SetActive(true);
            gm.GetComponent<GameManager>().DisplayOnBoard("Pick up the Parts on the left and add them to the Car Body");
        wall.SetActive(false);
        gm.GetComponent<GameManager>().DisplayOnArm("Build the Car");
        //}
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
