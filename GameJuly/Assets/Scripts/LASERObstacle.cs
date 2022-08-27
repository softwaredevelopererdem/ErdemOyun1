using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LASERObstacle : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private GameObject pointA;
    private GameObject pointB;
    private BoxCollider boxCollider;    
    void Start()
    {
        pointA = transform.GetChild(0).gameObject;
        pointB = transform.GetChild(1).gameObject;
        lineRenderer = GetComponent<LineRenderer>();
         lineRenderer.SetPosition(0,pointA.transform.position);
        lineRenderer.SetPosition(1,pointB.transform.position);
        
         
        boxCollider= GetComponent<BoxCollider>();
        boxCollider.center =transform.InverseTransformPoint(new Vector3(lineRenderer.bounds.center.x, lineRenderer.bounds.center.y / 2, lineRenderer.bounds.center.z))  ;
        boxCollider.size = new((pointB.transform.position - pointA.transform.position).magnitude, lineRenderer.transform.position.y, lineRenderer.startWidth);



    }


}
