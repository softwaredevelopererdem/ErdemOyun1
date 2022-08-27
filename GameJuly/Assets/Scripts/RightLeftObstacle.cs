using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RightLeftObstacle : MonoBehaviour
{

    private Vector3 rightSideMiddle;
    private Vector3 leftSideMiddle;

    private Vector3 rightSideLeft;
    private Vector3 leftSideLeft;

    private Vector3 rightSideRight;
    private Vector3 leftSideRight;


    private bool isToRightSide = true;

    private GameObject leftGameObject;
    private GameObject middleGameObject;
    private GameObject rightGameObject;

    void Start()
    {
     

        leftGameObject   = transform.GetChild(0).gameObject;
        middleGameObject = transform.GetChild(1).gameObject;
        rightGameObject  = transform.GetChild(2).gameObject;

        // rightPoint = transform.position + new Vector3(3.75f, 0, 0);//Global
        // rightSideMiddle = new Vector3(3.75f, middleGameObject.transform.localPosition.y, transform.localPosition.z);//Local
        // leftPoint = transform.position - new Vector3(3.75f, 0, 0);//Global
        // leftSideMiddle = new Vector3(-3.75f,middleGameObject. transform.localPosition.y, transform.localPosition.z);//Local

        rightSideMiddle = middleGameObject.transform.localPosition + new Vector3(3.75f,0,0);
        leftSideMiddle  = middleGameObject.transform.localPosition + new Vector3(-3.75f,0,0);

        rightSideLeft = leftGameObject.transform.localPosition + new Vector3(3.75f,0,0);
        leftSideLeft  = leftGameObject.transform.localPosition + new Vector3(-3.75f,0,0);

        rightSideRight = rightGameObject.transform.localPosition + new Vector3(3.75f,0,0);
        leftSideRight  = rightGameObject.transform.localPosition + new Vector3(-3.75f,0,0);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, rightPoint, 0.3f*Time.deltaTime);
        // transform.position = Vector3.MoveTowards(transform.position, leftPoint, 5*Time.deltaTime);
        if (isToRightSide)
        {
            
            middleGameObject.transform.localPosition = Vector3.MoveTowards(middleGameObject.transform.localPosition, rightSideMiddle, 5f * Time.deltaTime);
            leftGameObject.transform.localPosition   = Vector3.MoveTowards(leftGameObject.transform.localPosition, leftSideLeft, 5f * Time.deltaTime);
            rightGameObject.transform.localPosition  = Vector3.MoveTowards(rightGameObject.transform.localPosition, leftSideRight, 5f * Time.deltaTime);

            
        }
        if (!isToRightSide)
        {
            middleGameObject.transform.localPosition = Vector3.MoveTowards(middleGameObject.transform.localPosition, leftSideMiddle, 5f * Time.deltaTime);
            leftGameObject.transform.localPosition = Vector3.MoveTowards(leftGameObject.transform.localPosition,rightSideLeft, 5f * Time.deltaTime);
            rightGameObject.transform.localPosition = Vector3.MoveTowards(rightGameObject.transform.localPosition, rightSideRight, 5f * Time.deltaTime);
        }

        if (Vector3.Distance(middleGameObject.transform.localPosition, rightSideMiddle) < 0.1f)
        {
            isToRightSide = false;
        }
        if (Vector3.Distance(middleGameObject.transform.localPosition, leftSideMiddle) < 0.1f)
        {
            isToRightSide = true;
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RightLeftObstacle : MonoBehaviour
{


    private bool isCloseRight = false;

    private Vector3 rightPoint;
    private Vector3 leftPoint;

    private GameObject leftGameObject;
    private GameObject middleGameObject;
    private GameObject rightGameObject;


    private void Start()
    {
        leftGameObject = transform.GetChild(0).gameObject;
        middleGameObject = transform.GetChild(1).gameObject;
        rightGameObject = transform.GetChild(2).gameObject;


        rightPoint = middleGameObject.transform.position + new Vector3(3, 0, 0);
        leftPoint = middleGameObject.transform.position - new Vector3(3, 0, 0);
    }



    void Update()
    {

        if (Vector3.Distance(middleGameObject.transform.position, rightPoint) < 0.01)
        {
            isCloseRight = true;


        }
        if (Vector3.Distance(middleGameObject.transform.position, leftPoint) < 0.01)
        {
            isCloseRight = false;
        }
        if (isCloseRight)
        {
            middleGameObject.transform.position = middleGameObject.transform.position - new Vector3(2 * Time.deltaTime, 0, 0);
            rightGameObject.transform.position = rightGameObject.transform.position + new Vector3(2 * Time.deltaTime, 0, 0);
            leftGameObject.transform.position = leftGameObject.transform.position + new Vector3(2 * Time.deltaTime, 0, 0);

        }
        if (!isCloseRight)
        {
            middleGameObject.transform.position = middleGameObject.transform.position + new Vector3(2 * Time.deltaTime, 0, 0);
            rightGameObject.transform.position = rightGameObject.transform.position - new Vector3(2 * Time.deltaTime, 0, 0);
            leftGameObject.transform.position = leftGameObject.transform.position - new Vector3(2 * Time.deltaTime, 0, 0);

        }


    }
}

*/
