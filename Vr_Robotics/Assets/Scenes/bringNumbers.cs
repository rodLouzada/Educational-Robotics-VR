using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bringNumbers : MonoBehaviour
{
    public GameObject [] numbers ;
    public GameObject[] directions;
    public bool isActive = false;
    public hand [] h;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowNumbers()
        {
        foreach(GameObject b in numbers)
            {
                b.SetActive(true);
                isActive = true;
            foreach(hand hand in h)
                {
                hand.isActive += 1;
                }
            
            }
        
        }

    public void ShowDirections()
        {
        foreach (GameObject d in directions)
            {
            d.SetActive(true);
            isActive = true;
            foreach (hand hand in h)
                {
                hand.isActive += 1;
                }

            }

        }
    }
