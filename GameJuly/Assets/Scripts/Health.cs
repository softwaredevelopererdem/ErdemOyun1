using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private DataAsset dataAsset;

    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        dataAsset = GameObject.FindGameObjectWithTag("DataAsset").GetComponent<DataAsset>();
        player = GameObject.FindGameObjectWithTag("Player");


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && dataAsset.healthsList.Count<3)
        {

            GetComponent<BoxCollider>().enabled = false;
            player.GetComponent<CharacterController>().Move(Vector3.up);

            player.GetComponent<CharacterController>().center -= new Vector3(0, 1, 0);

            transform.parent = player.transform;
            transform.localPosition = transform.TransformDirection(transform.position = player.GetComponent<CharacterController>().center);
            dataAsset.healthsList.Add(this.gameObject);

        }
       

    }

}
