using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_make_vis : MonoBehaviour
{

    public bool chest_visible = false;
    public GameObject this_chest;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && chest_visible == false)
        {
            chest_visible = true;
            this_chest.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
