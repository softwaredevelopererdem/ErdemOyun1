using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public GameObject player1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player1.transform.position;
    }
}
