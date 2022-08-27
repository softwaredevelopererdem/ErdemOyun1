using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBackObstacle : MonoBehaviour
{
    private GameObject middeObstacle;
    private bool isClose = false;
    private Vector3 firstPosition;

    void Start()
    {
        middeObstacle = transform.parent.GetChild(1).gameObject;
        firstPosition = transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.z >= (middeObstacle.gameObject.transform.position.z - 5))
        {
            isClose = true;


        }
        if (transform.position.z < (middeObstacle.gameObject.transform.position.z - 10))
        {
            isClose = false;
        }

        //transform.localPosition = transform.localPosition + new Vector3(0, 0, displacement);

        if (isClose)
        {
            // transform.localPosition = Vector3.MoveTowards(transform.localPosition, middeObstacle.transform.position+new Vector3(0,0,2), 5f * Time.deltaTime);
            transform.localPosition = transform.localPosition - new Vector3(0, 0, 2 * Time.deltaTime);

        }
        if (!isClose)
        {
            //transform.localPosition = Vector3.MoveTowards(transform.localPosition, leftSideMiddle, 5 * Time.deltaTime);
            transform.localPosition = transform.localPosition + new Vector3(0, 0, 2 * Time.deltaTime);

        }


    }
}
