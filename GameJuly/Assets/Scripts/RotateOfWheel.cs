using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOfWheel : MonoBehaviour
{
    [SerializeField] private List<Transform> frontWheels;
    [SerializeField] private List<Transform> backWheels;
   [SerializeField] private float speed = 150;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

        foreach (Transform item in frontWheels)
        {

            item.Rotate(Vector3.up, speed * Time.deltaTime);


        }

        foreach (Transform item in backWheels)
        {

            item.Rotate(Vector3.up, -speed * Time.deltaTime);
        }

    }
}
