using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class codeList : MonoBehaviour
    {
    public List<GameObject> blocks;
    public List<_block> _main_block_list = new List<_block> ();
    string code = "func () {\n";

    public int numBocksIf = -1;
    int numBocksConc = 0;

    public bool active = false;
    bool enterIf = false;
    bool enterConc = false;

    public TextMeshProUGUI canvas;
    List<_block> currentList =  new List<_block>();
    public float something = 2;
    public Rigidbody car;
    public int lvl;
    public rayhit rh;
    public GameObject car2;
    

    public void recursiveLast(int it, List<_block> this_b, _block b)
        {
            if(it > 0)
            {
               recursiveLast(it-1, this_b[this_b.Count-1].child , b);
            }
            if(it == 0)
            {
            this_b.Add(b);
            }

        }
    private void Start()
        {
        numBocksIf = -1;
        }


    public void AddToList(GameObject g)
        {
        _block _b;
        _b.name = "name"; _b.rot = 0; _b.value = 0; _b.child = new List<_block>();
        _b.leftDirection = "";
        _b.leftRotations = "";
        _b.rightDirection = "";
        _b.rightRotations = "";
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

                if (numBocksIf == 0)
                    { code += "} //end else\n";
                    numBocksIf = -1;
                    lvl -= 1; }
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
                lvl -= 1;
                }
            if (g.name == "End Loop")
                {
                code += "} //end loop \n";
                lvl -= 1;
                }
            if (g.name == "Start Loop")
                {
                string txt = g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text;
                code += "for (int i=0, i>" + txt + " ,i++){ \n";
                _b.value = int.Parse(g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text);
                _b.name = "loop";
                recursiveLast(lvl, _main_block_list, _b);
                lvl += 1;

                }
            if (g.name == "Switch Div End")
                {
                numBocksIf -= 1;
                lvl -= 1;
                code += "}// end if \n else { \n";
                enterIf = false;
                _b.name = "else";
                recursiveLast(lvl, _main_block_list, _b);
                lvl += 1;
                }
            if (g.name == "Switch Div")
                {
                enterIf = true;
                numBocksIf = 0;
                string txt = g.gameObject.transform.GetChild(1).GetChild(0).name;
                code += "if ( " + txt + " > " + g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + " ){ \n";
                _b.value = int.Parse(g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text);
                _b.name = "if";
                recursiveLast(lvl, _main_block_list, _b);
                lvl += 1;
                }
            if (g.name == "R Motor")
                {
                code += "R_Motor( "+ g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + ", "+ g.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text + " )";
                _b.name = "R_Motor";
                recursiveLast(lvl, _main_block_list, _b);
                }
            if (g.name == "L Motor")
                {
                code += "L_Motor( " + g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + ", " + g.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text + " )";
                _b.name = "l_Motor";
                recursiveLast(lvl, _main_block_list, _b);
                }
            if (g.name == "Dual Motor")
                {
                string leftDirection = g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text;
                string leftRotations = g.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text;
                string rightDirection = g.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text;
                string rightRotations = g.gameObject.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text;
                _b = motors(leftDirection, leftRotations, rightDirection, rightRotations);
                recursiveLast(lvl, _main_block_list, _b);
                code += "Motor(Left_Motor(" + leftDirection + ", " + leftRotations + "), Right_Motor(" + rightDirection + ", " + rightRotations + ")); \n";
                }
            if (numBocksConc % 2 == 0) { code += " ,"; }
            else { code += "); \n"; numBocksIf -= 1; }
            numBocksConc += 1;
            }
        else
            {
            if (enterIf)
                { numBocksIf += 1; }
            else
                {
                if (numBocksIf > 0)
                    {
                    numBocksIf -= 1;
                    //if (numBocksIf == 1) { numBocksIf -= 2; }

                    }

                else if (numBocksIf == 0)
                    {
                    code += "} //end else\n";
                    numBocksIf = -1;
                    lvl -= 1; }
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
                lvl -= 1;
                }
            if (g.name == "End Loop")
                {
                code += "} //end loop \n";
                lvl -= 1;
                }
            if (g.name == "Start Loop")
                {
                string txt = g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text;
                code += "for (int i=0, i<" + txt + " ,i++){ \n";
                _b.value = int.Parse(g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text);
                _b.name = "loop";
                recursiveLast(lvl, _main_block_list, _b);
                lvl += 1;
                }
            if (g.name == "Switch Div End")
                {
                numBocksIf -= 1;
                int autlvl = lvl;
                lvl -= 1;
                code += "}// end if \n else { \n";

                enterIf = false;
                _b.name = "else";
                
                recursiveLast(lvl, _main_block_list, _b);
                lvl = autlvl;
                }
            if (g.name == "Switch Div")
                {
                enterIf = true;
                numBocksIf = 0;
                string txt = g.gameObject.transform.GetChild(1).GetChild(0).name;
                code += "if ( " + txt + " > " + g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + " ){ \n";
                _b.value = int.Parse(g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text);
                _b.name = "if";
                recursiveLast(lvl, _main_block_list, _b);
                lvl += 1;
                }
            if (g.name == "R Motor")
                {
                code += "R_Motor( " + g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + ", " + g.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text + " ); \n";
                _b.name = "R_Motor";
                recursiveLast(lvl, _main_block_list, _b);
                }
            if (g.name == "L Motor")
                {
                code += "L_Motor( " + g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text + ", " + g.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text + " ); \n";
                _b.name = "L_Motor";
                recursiveLast(lvl, _main_block_list, _b);
                }
            if (g.name == "Dual Motor")
                {
                string leftDirection = g.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text;
                string leftRotations = g.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text;
                string rightDirection = g.gameObject.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text;
                string rightRotations = g.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text;
                _b = motors(leftDirection, leftRotations, rightDirection, rightRotations);
                recursiveLast(lvl, _main_block_list, _b);
                code += "Motor(Left_Motor(" + leftDirection + ", " + leftRotations + "), Right_Motor(" + rightDirection + ", " + rightRotations + ")); \n";
                }
            }
        }

    _block motors(string leftDirection, string leftRotations, string rightDirection, string rightRotations)
        {
        _block b;
        b.name = "motor"; b.rot = 0; b.value = 0; b.child = new List<_block>();
        b.leftDirection = leftDirection;
        b.leftRotations = leftRotations;
        b.rightDirection = rightDirection;
        b.rightRotations = rightRotations;

        if (leftDirection == rightDirection) // rotating the same direction
            {
            if(leftDirection == "F") // the car goes foward
                {
                b.rot = 1; //rot 1 = going foward
                b.value = int.Parse(leftRotations);
                }
            else // the car goes backwards 
                {
                b.rot = 2; //rot 2 = going backward
                b.value = int.Parse(leftRotations);
                }
            }
        else // the car will rotate on its axis
            {
            if (leftDirection == "F")
                {
                b.rot = 3;// rotate clockwise
                b.value = int.Parse(leftRotations);
                }
            else
                {
                b.rot = 4;//rotate counter clockwise
                b.value = int.Parse(leftRotations);
                }
            }
        return b;
        }
    public struct _block
        {
        public List<_block> child;
        public string name;
        public int value;
        public int rot;

        public string leftDirection;
        public string leftRotations;
        public string rightDirection;
        public string rightRotations;


        }

    public IEnumerator runCode(List<_block> lb)
        {
        foreach(_block b in lb)
            {
            yield return StartCoroutine(functions(b, lb));
            }
        }
    
    public IEnumerator functions(_block b, List<_block> lb)
        {
        string name = b.name;
        string src,aux;
        int forindex;

        if (name == "loop")
            {
            forindex = code.IndexOf("f");
            for (int i = 0; i < b.value; i++)
                {
                /*foreach (_block _b in b.child)
                    {
                    currentList = b.child;
                    functions(_b);
                    }*/
                Debug.Log("For i: " + i.ToString());
                src = "for (int i=";
                aux = "<color=#ff0000ff>" + src + "</color>";
                code = code.Replace(src, aux);
                              

                src = ", i<";
                aux = "<color=#ff0000ff>" + src + "</color>";
                code = code.Replace(src, aux);

                src = " ,i++){";
                aux = "<color=#ff0000ff>" + src + "</color>";
                code = code.Replace(src, aux);
                
                yield return new WaitForSeconds(0.5f);

                src = "for (int i=";
                aux = "<color=#000000ff>" + src + "</color>";
                code = code.Replace(src, aux);


                src = ", i<";
                aux = "<color=#000000ff>" + src + "</color>";
                code = code.Replace(src, aux);

                src = " ,i++){";
                aux = "<color=#000000ff>" + src + "</color>";
                code = code.Replace(src, aux); 

                yield return StartCoroutine(runCode(b.child));
                }
            src = "} //end loop";
            aux = "<color=#ff0000ff>" + src + "</color>";
            code = code.Replace(src, aux);

            yield return new WaitForSeconds(1f);

            aux = "<color=#000000ff>" + src + "</color>";
            code = code.Replace(src, aux);
            }
        if (name == "if")
            {
            src = "if (";
            aux = "<color=#ff0000ff>" + src + "</color>";
            code = code.Replace(src, aux);

            yield return new WaitForSeconds(1f);
            src = "if (";
            aux = "<color=#000000ff>" + src + "</color>";
            code = code.Replace(src, aux);

            int idx = lb.FindIndex(x => x.Equals(b));// currentList.IndexOf(b); // get "if_blok" position at list
            _block elseB = lb[idx + 1]; // next item will be "else_block"
            //lb.RemoveAt(idx + 1); // we remove that item because we dont want to go over it again (kinda not neccessary);
            float distance = rh.distanceHit;
            if (distance > ((b.value*0.01)+0.14))
                {
                

                yield return StartCoroutine(runCode(b.child));

                src = "}// end if";
                aux = "<color=#ff0000ff>" + src + "</color>";
                code = code.Replace(src, aux);

                yield return new WaitForSeconds(1f);

                aux = "<color=#000000ff>" + src + "</color>";
                code = code.Replace(src, aux);

                }
            else
                {

                src = "else {";
                aux = "<color=#ff0000ff>" + src + "</color>";
                code = code.Replace(src, aux);

                yield return new WaitForSeconds(1f);

                aux = "<color=#000000ff>" + src + "</color>";
                code = code.Replace(src, aux);

                foreach (_block _b in elseB.child)
                    {
                    yield return StartCoroutine(runCode(elseB.child));
                    }
                src = "} //end else";
                aux = "<color=#ff0000ff>" + src + "</color>";
                code = code.Replace(src, aux);

                yield return new WaitForSeconds(1f);

                aux = "<color=#000000ff>" + src + "</color>";
                code = code.Replace(src, aux);
                }
            }
        if (name == "motor")
            {
            Debug.Log("motor: " + b.rot.ToString() + " rotation, " + b.value.ToString() + " values \n");

            src = "Motor(Left_Motor(" + b.leftDirection + ", " + b.leftRotations + "), Right_Motor(" + b.rightDirection + ", " + b.rightRotations + "));";
            aux = "<color=#ff0000ff>" + src + "</color>";
            code = code.Replace(src, aux);

            

            if (b.rot == 1) //FOWARD
                {
                /*Vector3 currentPos = car.gameObject.transform.position;
                Vector3 newPos = new Vector3(0, 0, b.value * 0.1f);
                car.MovePosition(currentPos + newPos);*/
                Debug.Log("1");
                car.AddRelativeForce(Vector3.forward * 70);
                yield return new WaitForSeconds(0.5f);
                }
            if (b.rot == 2) //BACKWARD
                {
                /*Vector3 currentPos = car.gameObject.transform.position;
                Vector3 newPos = new Vector3(0, 0, -0.1f);
                car.gameObject.transform.position = Vector3.Lerp(currentPos, newPos,0.01f); */
                car.AddRelativeForce(-Vector3.forward * 70);
                //yield return new WaitForSeconds(0.5f);
                Debug.Log("2");
                }
            if (b.rot == 3)// rotate clockwise
                {

                //Vector3 currentPos = car.gameObject.transform.localPosition;
                //Vector3 newPos = new Vector3(0, 0, 0.05f* b.value);

                //car2.GetComponent<MoveCar>().RotateRight(b.value);
                car.useGravity = false;
                car.AddTorque(Vector3.up * 1000f, ForceMode.Impulse);
                yield return new WaitForSeconds(0.487f);
                car.useGravity = true;
                //yield return new WaitForSeconds(0.5f);
                Debug.Log("3");




                }
            if (b.rot == 4) //Rotate counterclockwise
                {
                car.useGravity = false;
                car.AddTorque(Vector3.up * -1000f, ForceMode.Impulse);
                yield return new WaitForSeconds(0.487f);

                car.useGravity = true;
            }

            yield return new WaitForSeconds(1f);

            aux = "<color=#000000ff>" + src + "</color>";
            code = code.Replace(src, aux);
            yield return null;


            }
        yield return null;
        }


        // Update is called once per frame
        void FixedUpdate()
        {
        if (active)
            {
            //string code = GenerateCode();
            //Debug.Log(code);

            StartCoroutine( runCode(_main_block_list));
            active = false;
            }

        canvas.text = code;
        }

    void waiting (float in_time)
        {
        float currTime = 0;
        while (currTime < in_time)
            {
            currTime += Time.deltaTime;
            Debug.Log(currTime);
            }
        }
    }
