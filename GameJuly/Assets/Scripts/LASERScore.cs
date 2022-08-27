using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LASERScore : MonoBehaviour
{
    [HideInInspector] public float laserScore=0;
    private bool isComplatedLASER = false;
    private DataAsset dataAsset;
    void Start()
    {
        dataAsset = GameObject.FindGameObjectWithTag("DataAsset").GetComponent<DataAsset>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (laserScore==2 && isComplatedLASER==false)
        {
            dataAsset.money += 1;
            isComplatedLASER=true;
        }
    }
}
