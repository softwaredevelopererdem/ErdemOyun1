using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class LineFirst : MonoBehaviour
{
    public GameObject firstBox;
    public GameObject secondBox;
    private LineRenderer lr;

    CapsuleCollider capsule;

    private bool isPermission = true;

   [SerializeField] private Vector3 lineOffset = Vector3.zero;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        capsule = GetComponent<CapsuleCollider>();
        capsule.radius = lr.startWidth / 2;
        // capsule.center = Vector3.zero;
        capsule.direction = 2; // Z-axis

        lr.material = lr.materials[Random.Range(0, 4)];

    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, firstBox.transform.position+lineOffset);
        lr.SetPosition(1, secondBox.transform.position+lineOffset);

        //capsule.transform.position = transform.position;

        capsule.height = (secondBox.transform.position - firstBox.transform.position).magnitude;
        capsule.center = transform.InverseTransformPoint(lr.bounds.center);


        //GenerateMeshCollider();
    }
    public void GenerateMeshCollider()
    {
        MeshCollider mc = GetComponent<MeshCollider>();
        if (mc == null)
        {
            mc = gameObject.AddComponent<MeshCollider>();
        }

        Mesh mesh = new Mesh();
        lr.BakeMesh(mesh, true);
        mc.sharedMesh = mesh;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isPermission == true)
        {
            transform.parent.GetComponent<LASERScore>().laserScore += 1;

            lr.enabled = false;
            isPermission = false;
        }


    }

}
