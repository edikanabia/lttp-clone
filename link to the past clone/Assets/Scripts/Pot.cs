using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public Transform potTransform;
    
    public GameObject heartPrefab;
    public float heartChance = 0.75f;
    public GameObject rupeePrefab;
    public float rupeeChance = 0.5f;

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
    
}
