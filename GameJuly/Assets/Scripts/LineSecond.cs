using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class LineSecond : MonoBehaviour
{
    public GameObject firstBox;
    public GameObject secondBox;
   private LineRenderer lr;

    CapsuleCollider capsule;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        capsule=GetComponent<CapsuleCollider>();
        capsule.radius = lr.startWidth/ 2;
       // capsule.center = Vector3.zero;
        capsule.direction = 2; // Z-axis
         
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(1, firstBox.transform.position);
        lr.SetPosition(2, secondBox.transform.position);

        //capsule.transform.position = transform.position;

        capsule.height = (secondBox.transform.position- firstBox.transform.position).magnitude;
        capsule.center =transform.InverseTransformPoint(lr.bounds.center) ;


        //GenerateMeshCollider();
    }
    public void GenerateMeshCollider()
    {
        MeshCollider mc =GetComponent<MeshCollider>();
        if (mc==null)
        {
            mc = gameObject.AddComponent<MeshCollider>();
        }

        Mesh mesh= new Mesh();
        lr.BakeMesh(mesh,true);
        mc.sharedMesh = mesh;


    }
   
}
