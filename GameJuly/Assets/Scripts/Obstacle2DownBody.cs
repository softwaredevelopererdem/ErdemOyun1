using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Obstacle2DownBody : MonoBehaviour
{
    private float firstX = 0;
    private float firstZ = 0;
    private float lastX = 0;
    private float lastZ = 0;
    private float differencesFirstLastX=0;
    private float differencesFirstLastZ=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastX = transform.position.x;
        differencesFirstLastX=lastX-firstX; 
        firstX=transform.position.x;

        lastZ = transform.position.z;
        differencesFirstLastZ=lastZ-firstZ; 
        firstZ=transform.position.z;


        
        
        if (differencesFirstLastX>0 && differencesFirstLastZ>0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0,30,0),200f*Time.deltaTime);
            transform.GetChild(0).GetChild(1).Rotate(Vector3.up, 250 * Time.deltaTime);
            transform.GetChild(0).GetChild(2).Rotate(Vector3.up, 250 * Time.deltaTime);

        } 
        if (differencesFirstLastX<0 && differencesFirstLastZ<0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0,30,0),200f*Time.deltaTime);
            transform.GetChild(0).GetChild(1).Rotate(Vector3.up, -250 * Time.deltaTime);
            transform.GetChild(0).GetChild(2).Rotate(Vector3.up, -250 * Time.deltaTime);
        } 
        if (differencesFirstLastX<0 && differencesFirstLastZ>0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0,-30,0),200f*Time.deltaTime);
            transform.GetChild(0).GetChild(1).Rotate(Vector3.up, 250 * Time.deltaTime);
            transform.GetChild(0).GetChild(2).Rotate(Vector3.up, 250 * Time.deltaTime);
        } 
        if (differencesFirstLastX>0 && differencesFirstLastZ<0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0,-30,0),200f*Time.deltaTime);
            transform.GetChild(0).GetChild(1).Rotate(Vector3.up, -250 * Time.deltaTime);
            transform.GetChild(0).GetChild(2).Rotate(Vector3.up, -250 * Time.deltaTime);
        }
    }
}
