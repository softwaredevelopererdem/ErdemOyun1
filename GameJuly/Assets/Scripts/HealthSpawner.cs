using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject health;
    private GameObject healthSpawn;
    private DataAsset dataAsset;
    private void Start()
    {
           
          dataAsset = GameObject.FindGameObjectWithTag("DataAsset").GetComponent<DataAsset>();
        /*  if (dataAsset.oneInFive == 0)
          {
              healthSpawn = Instantiate(health,transform.parent);
              healthSpawn.gameObject.transform.localPosition = new Vector3(Random.Range(-3, 4), 1, Random.Range(-10,10));
          }
         */

        healthSpawn = Instantiate(health, transform.parent);
        healthSpawn.gameObject.transform.localPosition = new Vector3(Random.Range(-3, 4), 1, Random.Range(-10, 10));




    }
}
