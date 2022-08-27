using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBot2 : MonoBehaviour
{
    private float firstX = 0;
    private float firstZ = 0;
    private float lastX = 0;
    private float lastZ = 0;
    private float differencesFirstLastX = 0;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastX = transform.position.x;
        differencesFirstLastX = lastX - firstX;
        firstX = transform.position.x;

        if (differencesFirstLastX>0)
        {
            transform.GetChild(0).GetChild(1).Rotate(Vector3.up, -250 * Time.deltaTime);
            transform.GetChild(0).GetChild(2).Rotate(Vector3.up, -250 * Time.deltaTime);
        } 
        
        if (differencesFirstLastX<0)
        {
            transform.GetChild(0).GetChild(1).Rotate(Vector3.up, 250 * Time.deltaTime);
            transform.GetChild(0).GetChild(2).Rotate(Vector3.up, 250 * Time.deltaTime);
        }









    }
}
