using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player1 : MonoBehaviour
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

    public GameObject bomb;
    private float firstX = 0;
    private float firstZ = 0;
    private float lastX = 0;
    private float lastZ = 0;
    private float differencesFirstLastX = 0;
    private float differencesFirstLastZ = 0;
    private bool isNotMove = false;  
    private MeshRenderer bombRenderer;
    private GameObject myMeshController;
    private SkinnedMeshRenderer myMesh;
    private bool isDead = false; 

    void Start()
    {

        cc = GetComponent<CharacterController>();
        dataAsset = GameObject.FindGameObjectWithTag("DataAsset").GetComponent<DataAsset>();
        animator=GetComponent<Animator>();
        myMeshController = GameObject.FindWithTag("Renderer");
        myMesh = myMeshController.GetComponent<SkinnedMeshRenderer>();
        



    }

    // Update is called once per frame
    void Update()
    {

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        //cc.Move(new Vector3(x, falingDric.y, z) * Time.deltaTime * 15);
        

        //faling
        falingDric.y += Physics.gravity.y * Time.deltaTime / 10;
        cc.Move(falingDric * Time.deltaTime);

        //jumping
        if (isDead == false)
        {
            cc.Move(new Vector3(x, falingDric.y, speed) * Time.deltaTime * 15);
        }

       
        

        

       

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

        if (!cc.isGrounded)
        {
            animator.SetFloat("x", 0);
            animator.SetFloat("y", 0);
        }
        if (cc.isGrounded && isNotMove == false)
        {
            animator.SetFloat("x", 0);
            animator.SetFloat("y", 1);
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
        if (other.gameObject.tag == "MobileObstacle")
        {
            isDead = true;
            bomb.SetActive(true);
            myMesh.enabled = false;


           


            //  Destroy(dataAsset.healthsList[dataAsset.healthsList.Count - 1].gameObject);
            //  dataAsset.healthsList.RemoveAt(dataAsset.healthsList.Count - 1);
            // cc.center += new Vector3(0, 1, 0);
            //  cc.Move(Vector3.down * 2);

        }
     
              
    }
    void gameObjectOut()
    {
        Destroy(gameObject);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (hit.gameObject.tag == "Laser")
        {
            animator.SetFloat("x", 0);
            animator.SetFloat("y", 0);
            isNotMove = true;
            if (cc.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                hit.gameObject.GetComponent<Collider>().enabled=false;
                falingDric.y += Mathf.Sqrt(0.01f * -1.0f * Physics.gravity.y);
                isNotMove = false;
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