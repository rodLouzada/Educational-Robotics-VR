using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject initialSetup;
    public GameObject guidedBuildingBlock;
    public GameObject guidedBuilding;
    public GameObject codeBuilder;
    public GameObject whiteBoard;


    // Start is called before the first frame update
    void Start()
    {
        initialSetup.SetActive(true);
        guidedBuilding.SetActive(false);
        codeBuilder.SetActive(false);
    }

    public void DisplayOnBoard(string s)
    {
        whiteBoard.GetComponent<Text>().text = s;
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
