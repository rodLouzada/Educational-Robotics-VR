using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class codeList : MonoBehaviour
    {
    public List<GameObject> blocks;
    public bool active = false;
    string code = "func () {\n";
    public int numBocksIf = 0;
    bool enterIf = false;
    int numBocksConc = 0;
    bool enterConc = false;
    public void AddToList(GameObject g)
        {
        if (g.name == "Concurrent End")
            {
            enterConc = false;

            }
        else
        blocks.Add(g);
        if (enterConc)
            {
            if (numBocksConc % 2 == 0) { code += "Concurrent( "; }
            //else { code += ","; }
            if (enterIf) { numBocksIf += 1; }
            else
                {
                if (numBocksIf > 0)
                    {
                    numBocksIf -= 1;

                    }

                if (numBocksIf == 0) { code += "} //end else\n"; numBocksIf = -1; }
                }
            if (g.name == "Start")
                {
                code = "main(){ \n";
                }
            if (g.name == "Concurrent End")
                {
                enterConc = false;

                }
            if (g.name == "Concurrent Start")
                {
                enterConc = true;
                }
            if (g.name == "End")
                {
                code += "} //end func \n";
                }
            if (g.name == "End Loop")
                {
                code += "} //end loop \n";
                }
            if (g.name == "Start Loop")
                {
                string txt = g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text;
                code += "for (int i=0, i>" + txt + " ,i++){ \n";
                }
            if (g.name == "Switch Div End")
                {
                numBocksIf -= 1;
                code += "}// end if \n else { \n";
                enterIf = false;
                }
            if (g.name == "Switch Div")
                {
                enterIf = true;
                numBocksIf = 0;
                string txt = g.gameObject.transform.GetChild(1).GetChild(0).name;
                code += "if ( " + txt + " > " + g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + " ){ \n";
                }
            if (g.name == "R Motor")
                {
                code += "R_Motor( "+ g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + ", "+ g.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text + " )";
                }
            if (g.name == "L Motor")
                {
                code += "L_Motor( " + g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + ", " + g.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text + " )";
                }
            if (numBocksConc % 2 == 0) { code += " ,"; }
            else { code += "); \n"; numBocksIf -= 1; }
            numBocksConc += 1;
            }
        else
            {
            if (enterIf) { numBocksIf += 1; }
            else
                {
                if (numBocksIf > 0)
                    {
                    numBocksIf -= 1;
                    //if (numBocksIf == 1) { numBocksIf -= 2; }

                    }

                if (numBocksIf == 0) { code += "} //end else\n"; numBocksIf = -1; }
                }
            
            if (g.name == "Start")
                {
                code = "main(){ \n";
                }
            if (g.name == "Concurrent End")
                {
                if (enterIf) { numBocksIf -= 1; }
                enterConc = false;
                }
            if (g.name == "Concurrent Start")
                {
                enterConc = true;
                if (enterIf) { numBocksIf -= 1; }
                }
            if (g.name == "End")
                {
                code += "} //end func \n";
                }
            if (g.name == "End Loop")
                {
                code += "} //end loop \n";
                }
            if (g.name == "Start Loop")
                {
                string txt = g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text;
                code += "for (int i=0, i<" + txt + " ,i++){ \n";
                }
            if (g.name == "Switch Div End")
                {
                numBocksIf -= 1;
                code += "}// end if \n else { \n";
                enterIf = false;
                }
            if (g.name == "Switch Div")
                {
                enterIf = true;
                numBocksIf = 0;
                string txt = g.gameObject.transform.GetChild(1).GetChild(0).name;
                code += "if ( " + txt + " > " + g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + " ){ \n";
                }
            if (g.name == "R Motor")
                {
                code += "R_Motor( " + g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + ", " + g.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text + " ); \n";
                }
            if (g.name == "L Motor")
                {
                code += "L_Motor( " + g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + ", " + g.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text + " ); \n";
                }
            }






        }

    // Update is called once per frame
    void Update()
        {
        if (active)
            {
            //string code = GenerateCode();
            Debug.Log(code);
            }
        }

    public string GenerateCode()
        {
        string code = "main() {\n";
        int contBlocks = 0;
        GameObject prev = null;
        foreach (GameObject g in blocks)
            {
            if (g.name == "Start")
                {
                code = "main(){ \n";
                }
            if (g.name == "Concurrent End")
                {


                }
            if (g.name == "Concurrent Start")
                {

                }
            if (g.name == "End Block")
                {
                code += "}\n";
                }
            if (g.name == "End Loop")
                {
                code += "}\n";
                }
            if (g.name == "Start Loop")
                {
                string txt = g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text;
                code += "for (int i=0, i>" + txt + " ,i++){ \n";
                }
            if (g.name == "Concurrent Start")
                {

                }
            if (g.name == "Switch Div End")
                {
                code += "}\n else { \n";
                }
            if (g.name == "Switch Div")
                {
                //string txt = prev.gameObject.name;
                code += "if ( sensor > " + g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + " ){ \n";
                }

            prev = g;
            }
        return code;
        }
    }
