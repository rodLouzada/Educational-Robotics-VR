using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using System.Linq;
using System.Text;
using System.IO;

public class saveObject : MonoBehaviour
{
    string localPath;
    public codeList cl;
    DateTime date;
    string texttosave;
    void Start()
    {
        date = DateTime.Now;
        localPath = "Assets\\Collection\\" + date.ToString("yyyy-MM-ddTHH-mm-ss") + ".txt";
        texttosave = cl.code;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("hand"))
        {
            StreamWriter writer = new StreamWriter(localPath, true);
            writer.Write(cl.code);
            writer.Close();
            this.gameObject.SetActive(false);
        }
    }
}
