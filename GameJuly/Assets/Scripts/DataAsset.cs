using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataAsset : MonoBehaviour

{

    private GameObject player;
    public int oneInFive = 5;
    //public Color red = Color.red;
    //public Color blue = Color.blue;

    public List<GameObject> healthsList;
    // Start is called before the first frame update
    public float money = 0;


    public List<Material> laserMaterials;
    void Start()
    {
        healthsList = new List<GameObject>();
        player = GameObject.FindWithTag("Player");

        healthsList.Add(player);

        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetFloat("Money");
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (oneInFive <= 0)
        {
            oneInFive = 5;
        }

        PlayerPrefs.SetFloat("Money", money);

        Debug.Log("money  " + money);
    }
}
