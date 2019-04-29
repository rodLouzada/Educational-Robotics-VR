using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePhase : MonoBehaviour
{
    public GameObject rhand;
    public GameObject lhand;
    public GameObject gm;

    // Start is called before the first frame update
    void Start()
        {

        }

    private void OnTriggerEnter(Collider col)
        {
        if (col.CompareTag("hand")){
            gm.GetComponent<GameManager>().initialSetup.SetActive(false);
            gm.GetComponent<GameManager>().guidedBuilding.SetActive(false);
            gm.GetComponent<GameManager>().codeBuilder.SetActive(true);

            }
        }

    // Update is called once per frame
    void Update()
        {

        }
    }
