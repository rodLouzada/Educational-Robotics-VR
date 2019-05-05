using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject initialSetup;
    public GameObject guidedBuildingBlock;
    public GameObject guidedBuilding;
    public GameObject codeBuilder;
    public TextMeshProUGUI armText;
    public TextMeshProUGUI whiteBoard;


    // Start is called before the first frame update
    void Start()
    {
        initialSetup.SetActive(true);
        guidedBuilding.SetActive(false);
        codeBuilder.SetActive(false);

        DisplayOnArm("Welcome to VR Robotics");
    }

    public void DisplayOnBoard(string s)
    {
        whiteBoard.text = s;
    }

    public void DisplayOnArm(string s)
    {
        //armText.GetComponent<Text>().text = s;
        armText.text = s;
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
