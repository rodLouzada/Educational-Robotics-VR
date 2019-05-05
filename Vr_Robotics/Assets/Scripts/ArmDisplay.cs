using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmDisplay : MonoBehaviour
{
    public GameObject arm;

    // Start is called before the first frame update
    void Start()
    {
        this.DisplayOnArm("YEET");
    }

    public void DisplayOnArm(string s)
        {
        arm.GetComponent<Text>().text = s;
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
