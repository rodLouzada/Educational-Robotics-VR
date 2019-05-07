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
    private bool StepFiveDone = false;
    private bool StepSixDone = false;
    private bool StepSevenDone = false;
    private bool StepEightDone = false;


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

        else if((block1.Equals(dualMotorBlock1) && block2.Equals(switchDivBlock)))
        {
            block2 = startBlock;
            check = block2.transform.Find("Next/Start Loop/Next/Switch Div/Next/Next Top/Dual Motor").gameObject;
        }
        
        else if(block1.Equals(dualMotorBlock2) && block2.Equals(switchDivBlock))
        {
            block2 = startBlock;
            check = block2.transform.Find("Next/Start Loop/Next/Switch Div/Next/Next Bottom/Dual Motor").gameObject;
        }

        else if (block1.Equals(startBlock) && block2.Equals(switchDivEndBlock))
        {
            check = block1.transform.Find("Next/Start Loop/Next/Switch Div/Next/Next Top/Dual Motor/L Motor/Right Motor Block/Concurrent End Block/Concurrent End/Next/Switch Div End").gameObject;
        }

        else if (block1.Equals(switchDivEndBlock) && block2.Equals(loopEndBlock))
        {
            block1 = startBlock;
            check = block1.transform.Find("Next/Start Loop/Next/Switch Div/Next/Next Top/Dual Motor/L Motor/Right Motor Block/Concurrent End Block/Concurrent End/Next/Switch Div End/Next/End Loop").gameObject;
        }

        else if (block1.Equals(loopEndBlock) && block2.Equals(EndBlock))
        {
            block1 = startBlock;
            check = block1.transform.Find("Next/Start Loop/Next/Switch Div/Next/Next Top/Dual Motor/L Motor/Right Motor Block/Concurrent End Block/Concurrent End/Next/Switch Div End/Next/End Loop/Next/End").gameObject;
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
                gm.DisplayOnArm("Connect the top [Dual Motor] Block to the [Switch] Block");

                startBlock.GetComponent<makeGlow>().makeItGlow = false;
                switchDivBlock.GetComponent<makeGlow>().makeItGlow = false;

                dualMotorBlock1.GetComponent<makeGlow>().makeItGlow = true;
                //dualMotorBlock2.GetComponent<makeGlow>().makeItGlow = true;
                switchDivBlock.GetComponent<makeGlow>().makeItGlow = true;

                StepThreeDone = true;
                }
            }

        if ( !StepFourDone && areConnected(dualMotorBlock1, switchDivBlock))
        {
            gm.DisplayOnArm("Connect the other [Dual Motor] Block to the [Switch Div] Block");

            dualMotorBlock2.GetComponent<makeGlow>().makeItGlow = true;
            switchDivBlock.GetComponent<makeGlow>().makeItGlow = true;



            StepFourDone = true;
        }

        if(!StepFiveDone && areConnected(dualMotorBlock2, switchDivBlock))
        {
            gm.DisplayOnArm("You still gotta close the [Div] dumbfuck");

            dualMotorBlock2.GetComponent<makeGlow>().makeItGlow = false;
            switchDivBlock.GetComponent<makeGlow>().makeItGlow = false;

            startBlock.GetComponent<makeGlow>().makeItGlow = true;
            switchDivEndBlock.GetComponent<makeGlow>().makeItGlow = true;

            StepFiveDone = true;
        }

        if(!StepSixDone && areConnected(startBlock, switchDivEndBlock))
        {
            gm.DisplayOnArm("Ok now close that Fuckin loop");

            startBlock.GetComponent<makeGlow>().makeItGlow = true;
            loopEndBlock.GetComponent<makeGlow>().makeItGlow = true;

            StepSixDone = true;
        }

        if (!StepSevenDone && areConnected(switchDivEndBlock, loopEndBlock))
        {
            gm.DisplayOnArm("Add an end bracket ya fuckin moron");

            startBlock.GetComponent<makeGlow>().makeItGlow = true;
            loopEndBlock.GetComponent<makeGlow>().makeItGlow = false;
            EndBlock.GetComponent<makeGlow>().makeItGlow = true;

            StepSevenDone = true;
        }

        if (!StepEightDone && areConnected(loopEndBlock, EndBlock))
        {
            gm.DisplayOnArm("You're done you dumb bitch");

            startBlock.GetComponent<makeGlow>().makeItGlow = false;
            EndBlock.GetComponent<makeGlow>().makeItGlow = false;


            StepEightDone = true;
        }

    }

       
    }
