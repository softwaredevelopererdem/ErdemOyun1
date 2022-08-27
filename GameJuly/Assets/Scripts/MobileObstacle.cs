using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MobileObstacle : MonoBehaviour
{

    private DataAsset dataAsset;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        dataAsset = GameObject.FindWithTag("DataAsset").GetComponent<DataAsset>();
        player = GameObject.FindWithTag("Player");
      

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && dataAsset.healthsList.Count != 0)
        {
            
            Destroy(dataAsset.healthsList[dataAsset.healthsList.Count - 1].gameObject);
            dataAsset.healthsList.RemoveAt(dataAsset.healthsList.Count - 1);
            player.GetComponent<CharacterController>().center += new Vector3(0, 1, 0);
            player.GetComponent<CharacterController>().Move(Vector3.down*2);
        }

    }

}
