using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public Transform potTransform;
    public GameObject player;
    
    public GameObject heartPrefab;
    public float heartChance = 0.75f;
    public GameObject rupeePrefab;
    public float rupeeChance = 0.5f;

    public bool isChest = false;
    public bool isBigChest = false;
    bool playerHasBigKey = false;
    public bool chestHasKey = false;
    public GameObject keyPrefab;
    public bool chestHasBigKey = false;
    public GameObject bigKeyPrefab;
    public bool chestHasRupee = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
        if(!isChest && !isBigChest)
        {
            int pick = Random.Range(0, 2);

            if(pick == 0)
            {
                if(Random.Range(0f, 1f) >= heartChance)
                {
                    Instantiate(heartPrefab, potTransform.position, potTransform.rotation);
                }
            }
            else
            {
                if(Random.Range(0f, 1f) >= rupeeChance)
                {
                    Instantiate(rupeePrefab, potTransform.position, potTransform.rotation);
                }
            }  

            Destroy(this.gameObject);
        }
        else if(isChest)
        {
            if(chestHasRupee)
            {
                player.gameObject.GetComponent<PlayerController>().rupeeCount += 20;
            }

            if(chestHasKey)
            {
                player.gameObject.GetComponent<PlayerController>().keys += 1;
            }

            if(chestHasBigKey)
            {

                playerHasBigKey = true;
                
            }
        }
        else if(isBigChest && playerHasBigKey) 
        {
            player.GetComponent<Bow>().hasBow = true;
        }
    }
    
}
