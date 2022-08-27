using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObstacle : MonoBehaviour
{
    private Vector3 upPoint;
    private Vector3 downPoint;
    private bool isUpPoint = true;
    void Start()
    {
        upPoint = new Vector3(transform.localPosition.x, 3, transform.localPosition.z);//Localv        leftPoint = new Vector3(-3.75f, transform.localPosition.y, transform.localPosition.z);//Local
        downPoint = new Vector3(transform.localPosition.x, 0.5f, transform.localPosition.z);//Local

    }

    // Update is called once per frame
    void Update()
    {
        if (isUpPoint)
        {
             transform.localPosition = Vector3.MoveTowards(transform.localPosition, upPoint, 4f * Time.deltaTime);
           // transform.localPosition = Vector3.Lerp(transform.localPosition, rightPoint, 2f * Time.deltaTime);
        }
        if (!isUpPoint)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, downPoint, 4 * Time.deltaTime);
           // transform.localPosition = Vector3.Lerp(transform.localPosition, leftPoint, 2 * Time.deltaTime);
        }

        if (Vector3.Distance(transform.localPosition, upPoint) < 0.1f)
        {
            isUpPoint = false;
        }
        if (Vector3.Distance(transform.localPosition, downPoint) < 0.01f)
        {
            isUpPoint = true;
        }
    }
}
