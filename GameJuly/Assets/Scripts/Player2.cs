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
    private bool isDead = false;
    void Start()
    {

        cc = GetComponent<CharacterController>();
        dataAsset = GameObject.FindGameObjectWithTag("DataAsset").GetComponent<DataAsset>();
        animator=GetComponent<Animator>();


    }

    void Update()
    {

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        //cc.Move(new Vector3(x, falingDric.y, z) * Time.deltaTime * 15);
        if (isDead == false)
        {
            cc.Move(new Vector3(x, falingDric.y, speed) * Time.deltaTime * 15);
        }
        

        //faling
        falingDric.y += Physics.gravity.y * Time.deltaTime / 10;
        cc.Move(falingDric * Time.deltaTime);

        //jumping

       
        

        

       

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

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetFloat("x", -1);
                animator.SetFloat("y", 1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetFloat("x", 1);
                animator.SetFloat("y", 1);
            }
            else
            {
                animator.SetFloat("x", 0);
                animator.SetFloat("y", 1);
            }
            
        }


      

       
         

      

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Detector")
        {

            Instantiate(newPlatform, new Vector3(0, 0, other.gameObject.transform.parent.position.z + 480), Quaternion.identity);

        

        }
        if (other.gameObject.tag == "Line")
        {
            other.gameObject.GetComponent<CapsuleCollider>().enabled=false;
           // other.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        } 
        if (other.gameObject.tag == "MobileObstacle")
        {
            isDead = true;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            animator.SetTrigger("Die");
            Invoke("DestroyThisGameObject", 3.67f);
           
            //Invoke("DestroyThisGameObject" ,0.5f) ;




        }
     
              
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
      
        if (hit.gameObject.tag == "Laser")
        {   
            animator.SetFloat("x", 0);
            animator.SetFloat("x", 0);
            isNearLaser = true;
            if (cc.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
                hit.gameObject.GetComponent<Collider>().enabled=false;
                falingDric.y += Mathf.Sqrt(0.01f * -1.0f * Physics.gravity.y);  
                isNearLaser=false;
               

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

    void DestroyThisGameObject()
    {
        Destroy(gameObject);
    }
}