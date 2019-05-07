using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class saveObject : MonoBehaviour
{
    string localPath;
    public GameObject objToSave;
    DateTime date;
    void Start()
    {
        date = DateTime.Now;
        localPath = "Assets/Collection" + date.ToString() + ".prefab";
    }

    private void OnTriggerEnter(Collider col)
    {
        CreateNew(objToSave, localPath);
    }

    static void CreateNew(GameObject obj, string localPath)
    {
        //Create a new Prefab at the path given
        GameObject prefab = PrefabUtility.SaveAsPrefabAsset(obj, localPath);
        //PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.ConnectToPrefab);
    }
}
