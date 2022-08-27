using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController cc;
    public Vector3 falingDric;
    private float x;
    private float z;
    public int height = 0;

    public GameObject newPlatform;
    public GameObject health;
    public GameObject mobileObstacle;

    private DataAsset dataAsset;
    public float speed;
    void Start()
    {

        cc = GetComponent<CharacterController>();
        dataAsset = GameObject.FindGameObjectWithTag("DataAsset").GetComponent<DataAsset>();

    }

    // Update is called once per frame
    void Update()
    {

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        //cc.Move(new Vector3(x, falingDric.y, z) * Time.deltaTime * 15);
        cc.Move(new Vector3(x, falingDric.y, speed) * Time.deltaTime * 15);

        //faling
        falingDric.y += Physics.gravity.y * Time.deltaTime / 10;
        cc.Move(falingDric * Time.deltaTime);

        //jumping

        if (cc.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {

            falingDric.y += Mathf.Sqrt(0.01f * -3.0f * Physics.gravity.y);

        }

        if (cc.isGrounded && falingDric.y < 0)
        {
            falingDric.y = 0f;
        }




    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Detector")
        {

            Instantiate(newPlatform, new Vector3(0, 0, other.gameObject.transform.parent.position.z + 480), Quaternion.identity);

         /*   if (dataAsset.healthsList.Count < 3)
            {
                Instantiate(health, new Vector3(transform.position.x, 1, transform.position.z + 50), Quaternion.identity);

            }
         */
         //   Instantiate(mobileObstacle, new Vector3(transform.position.x, 1, transform.position.z + Random.Range(20, 60)), Quaternion.identity);
          //  Instantiate(mobileObstacle, new Vector3(transform.position.x, 1, transform.position.z + Random.Range(20, 60)), Quaternion.identity);
          //  Instantiate(mobileObstacle, new Vector3(transform.position.x, 1, transform.position.z + Random.Range(20, 60)), Quaternion.identity);

            // other.gameObject.SetActive(false);
            // dataAsset.oneInFive -= 1;

        }
        if (other.gameObject.tag == "Line")
        {
            other.gameObject.GetComponent<CapsuleCollider>().enabled=false;
           // other.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
              
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Line")
        {
            hit.gameObject.SetActive(false);
            Destroy(hit.gameObject);
        }
    }

}