using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBuildingGuide : MonoBehaviour
{
    //GameManager
    public GameObject gmObj;
    private GameManager gm;

    //Steps
    private bool StepZeroDone = false;
    private bool StepOneDone = false;
    private bool StepTwoDone = false;
    private bool StepThreeDone = false;
    private bool StepFourDone = false;


    //Coding Blocks
    public GameObject startBlock;
    public GameObject startLoopBlock;
    public GameObject sensorBlock;
    public GameObject switchDivBlock;
    public GameObject dualMotorBlock1;
    public GameObject dualMotorBlock2;
    public GameObject switchDivEndBlock;
    public GameObject loopEndBlock;
    public GameObject EndBlock;

    // Start is called before the first frame update
    void Start()
    {
        gm = gmObj.GetComponent<GameManager>();
    }

    bool areConnected(GameObject block1, GameObject block2)
        {
        GameObject check;

        if(block1.Equals(sensorBlock) && block2.Equals(switchDivBlock))
            {
                check = block2.transform.Find("Switch Div/Attachment/" + block1.name).gameObject;
            }
        else
             check = block1.transform.Find("Next/" + block2.name).gameObject;

        if (check != null)
            return true;
        else           
            return false;
        }

    // Update is called once per frame
    void Update()
        {
        //
        if (!StepZeroDone && this.gameObject.activeInHierarchy)
            {
            gm.DisplayOnArm("Connect [Start] Block to [Start Loop] Block");
            startBlock.GetComponent<makeGlow>().makeItGlow = true;
            startLoopBlock.GetComponent<makeGlow>().makeItGlow = true;

            StepZeroDone = true;
            }


        //first step
        if (!StepOneDone && areConnected(startBlock, startLoopBlock))
            {
            gm.DisplayOnArm("Connect [Sensor] Block to [Switch] Block");

            startBlock.GetComponent<makeGlow>().makeItGlow = false;
            startLoopBlock.GetComponent<makeGlow>().makeItGlow = false;

            switchDivBlock.GetComponent<makeGlow>().makeItGlow = true;
            sensorBlock.GetComponent<makeGlow>().makeItGlow = true;

            StepOneDone = true;
            }


        if (!StepTwoDone && areConnected(sensorBlock, switchDivBlock))
            {
            gm.DisplayOnArm("Connect the [Start]->[Start Loop] Block to the [Sensor]->[Switch] Block");

            switchDivBlock.GetComponent<makeGlow>().makeItGlow = false;
            sensorBlock.GetComponent<makeGlow>().makeItGlow = false;

            startBlock.GetComponent<makeGlow>().makeItGlow = true;
            switchDivBlock.GetComponent<makeGlow>().makeItGlow = true;

            StepTwoDone = true;
            }

        if (!StepThreeDone)
            {
            GameObject startComboBlock = startBlock.transform.Find("Next/Start Loop").gameObject;
            if (areConnected(startComboBlock, switchDivBlock))
                {
                gm.DisplayOnArm("Connect a [Dual Motor] Block to the [Switch] Block");

                startBlock.GetComponent<makeGlow>().makeItGlow = false;
                switchDivBlock.GetComponent<makeGlow>().makeItGlow = false;

                dualMotorBlock1.GetComponent<makeGlow>().makeItGlow = true;
                //dualMotorBlock2.GetComponent<makeGlow>().makeItGlow = true;
                startBlock.GetComponent<makeGlow>().makeItGlow = true;

                StepThreeDone = true;
                }
            }

        if ( !StepFourDone && areConnected(dualMotorBlock1, switchDivBlock) )
        {
            gm.DisplayOnArm("Yee haw");

            StepFourDone = true;
        }

        }

       
    }
