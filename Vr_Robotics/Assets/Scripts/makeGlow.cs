using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeGlow : MonoBehaviour
{
    public GameObject glow;
    public bool makeItGlow = false;

    public void MakeGlow ()
    {
        Behaviour halo = (Behaviour)glow.GetComponent("Halo");
        halo.enabled = true;
    }

    public void StopGlow()
    {
        Behaviour halo = (Behaviour)glow.GetComponent("Halo");
        halo.enabled = false;
    }

    void Update()
    {
        if (makeItGlow)
        {
            MakeGlow();
        }
        else StopGlow(); 
    } 
}
