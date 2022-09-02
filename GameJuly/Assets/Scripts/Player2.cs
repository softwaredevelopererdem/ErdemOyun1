using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController cc;
    public Vector3 falingDric;
    private float x;
    private float z;
    public int height = 0;

    public GameObject newPlatform;
    public GameObject health;
    // public GameObject mobileObstacle;

    private DataAsset dataAsset;
    public float speed;

    private Animator animator;


    private float firstX = 0;
    private float firstZ = 0;
    private float lastX = 0;
    private float lastZ = 0;
    private float differencesFirstLastX = 0;
    private float differencesFirstLastZ = 0;
    private bool isNearLaser = false;
    void Start()
    {

        cc = GetComponent<CharacterController>();
        dataAsset = GameObject.FindGameObjectWithTag("DataAsset").GetComponent<DataAsset>();
        animator = GetComponent<Animator>();



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









        if (cc.isGrounded && falingDric.y < 0)
        {
            falingDric.y = 0f;
        }



        lastX = transform.position.x;
        differencesFirstLastX = lastX - firstX;
        firstX = transform.position.x;

        lastZ = transform.position.z;
        differencesFirstLastZ = lastZ - firstZ;
        firstZ = transform.position.z;


        if (cc.isGrounded && isNearLaser == false)
        {
            animator.SetFloat("SagSol", 0);
            animator.SetFloat("IleriGeri", 1);
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
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            // other.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (other.gameObject.tag == "MobileObstacle")
        {

            Destroy(gameObject);

            //  Destroy(dataAsset.healthsList[dataAsset.healthsList.Count - 1].gameObject);
            //  dataAsset.healthsList.RemoveAt(dataAsset.healthsList.Count - 1);
            // cc.center += new Vector3(0, 1, 0);
            //  cc.Move(Vector3.down * 2);

        }


    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        animator.SetFloat("SagSol", 0);
        animator.SetFloat("IleriGeri", 0);
        if (hit.gameObject.tag == "Laser")
        {
            isNearLaser = true;
            if (cc.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                hit.gameObject.GetComponent<Collider>().enabled = false;
                animator.SetTrigger("Jump");
                falingDric.y += Mathf.Sqrt(0.01f * -3.0f * Physics.gravity.y);
                isNearLaser = false;


            }


        }
    }


    /*  private void OnControllerColliderHit(ControllerColliderHit hit)
      {
          if (hit.gameObject.tag == "Line")
          {
              hit.gameObject.SetActive(false);
              Destroy(hit.gameObject);
          }
      }
    */
}