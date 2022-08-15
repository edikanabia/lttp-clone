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
    public bool playerHasBigKey = false;
    public bool chestHasKey = false;
    public GameObject keyPrefab;
    public bool chestHasBigKey = false;
    public GameObject bigKeyPrefab;
    public bool chestHasRupee = false;

    public GameObject bowPrefab;
    public bool chestHasBow = false;

    public bool chest_is_open = false;
    //animators
    public Animator my_animator;
    

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
        if (!isChest && !isBigChest)
        {
            int pick = Random.Range(0, 2);

            if (pick == 0)
            {
                if (Random.Range(0f, 1f) >= heartChance)
                {
                    Instantiate(heartPrefab, potTransform.position, potTransform.rotation);
                }
            }
            else
            {
                if (Random.Range(0f, 1f) >= rupeeChance)
                {
                    Instantiate(rupeePrefab, potTransform.position, potTransform.rotation);
                }
            }

            Destroy(this.gameObject);
        }

    }

    


    private void OnCollisionStay2D(Collision2D contact)
    {
        if (contact.gameObject.tag == "Player" && isChest && chest_is_open == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                chest_is_open = true;
                my_animator.SetBool("is_open", true);
                if (chestHasRupee)
                {
                    var new_rupee = Instantiate(rupeePrefab);
                    rupeePrefab.transform.position = new Vector3(potTransform.position.x,
                        potTransform.position.y + 0.1f, potTransform.position.z);

                    StartCoroutine(CollectRupee(new_rupee));
                }
                

                if (chestHasKey)
                {
                    player.gameObject.GetComponent<temp_link_movement>().keys += 1;

                }

                if (chestHasBigKey)
                {
                    var new_big_key = Instantiate(bigKeyPrefab);
                    bigKeyPrefab.transform.position = new Vector3(potTransform.position.x,
                        potTransform.position.y + 0.1f, potTransform.position.z);

                    StartCoroutine(CollectBigKey(new_big_key));
                    
                }

            }

        } 

        if (contact.gameObject.tag == "Player" && isBigChest && playerHasBigKey)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                chest_is_open = true;
                my_animator.SetBool("is_open", true);
                var new_bow = Instantiate(bowPrefab);
                bowPrefab.transform.position = new Vector3(potTransform.position.x,
                        potTransform.position.y + 0.1f, potTransform.position.z);
                
                StartCoroutine(CollectBow(new_bow));

            }
               
        }

    }


 




    IEnumerator CollectRupee(GameObject this_one)
     {
         yield return new WaitForSeconds(1);
        player.gameObject.GetComponent<temp_link_movement>().rupeeCount += 20;
        Destroy(this_one);
    }

    IEnumerator CollectBigKey(GameObject this_one)
    {
        yield return new WaitForSeconds(1);
        playerHasBigKey = true;
        Destroy(this_one);
    }

    IEnumerator CollectBow(GameObject this_one)
    {
        yield return new WaitForSeconds(1);
        //player.GetComponent<Bow>().hasBow = true;
        Destroy(this_one);
    }


}
