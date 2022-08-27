using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    private Vector3 rightSide;
    private Vector3 leftSide;
    private bool isToRightSide = true;
   [SerializeField] private List<Transform> wheels;

    // Start is called before the first frame update
    void Start()
    {
        // rightPoint = transform.position + new Vector3(3.75f, 0, 0);//Global
        rightSide = new Vector3(3.75f, transform.localPosition.y, transform.localPosition.z);//Local
        // leftPoint = transform.position - new Vector3(3.75f, 0, 0);//Global
        leftSide = new Vector3(-3.75f, transform.localPosition.y, transform.localPosition.z);//Local

        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, rightPoint, 0.3f*Time.deltaTime);
        // transform.position = Vector3.MoveTowards(transform.position, leftPoint, 5*Time.deltaTime);
        if (isToRightSide)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, rightSide, 5f * Time.deltaTime);
            foreach (Transform item in wheels) {

                item.Rotate(Vector3.up,-150*Time.deltaTime);
            }
        }
        if (!isToRightSide)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, leftSide, 5 * Time.deltaTime);
            foreach (Transform item in wheels)
            {

                item.Rotate(Vector3.up, 150 * Time.deltaTime);
            }

        }

        if (Vector3.Distance(transform.localPosition, rightSide) < 0.1f)
        {
            isToRightSide = false;
        }
        if (Vector3.Distance(transform.localPosition, leftSide) < 0.1f)
        {
            isToRightSide = true;
        }
    }
}
