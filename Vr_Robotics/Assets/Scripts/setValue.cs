using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setValue : MonoBehaviour
{
    public Text container;
    public string value;
    public GameObject numbers;
    public hand [] h;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValues()
        {
        container.text = value;
        numbers.SetActive(false);
        
        foreach (hand hand in h)
            {
            hand.isActive -= 1;
            }
        }
}
