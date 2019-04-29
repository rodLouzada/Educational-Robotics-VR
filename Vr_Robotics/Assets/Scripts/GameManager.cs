using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject initialSetup;
    public GameObject guidedBuildingBlock;
    public GameObject guidedBuilding;
    public GameObject codeBuilder;

    // Start is called before the first frame update
    void Start()
    {
        initialSetup.SetActive(true);
        guidedBuilding.SetActive(false);
        codeBuilder.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
  
    }
}
