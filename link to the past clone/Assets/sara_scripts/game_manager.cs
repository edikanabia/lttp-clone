using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class game_manager : MonoBehaviour
{
    public bool game_paused = false;
    public GameObject menu;
    public GameObject player;

    public GameObject invent;
    public GameObject heart_icon;
    public GameObject rupee_icon;
    public GameObject key_icon;
    public GameObject bow_icon;
    public GameObject life_icon;

    //text
    public TextMeshProUGUI rupee_n;
    public TextMeshProUGUI key_n;
    public TextMeshProUGUI life_n;

    //numbers
    int life_a;
    int rupee_a;
    int key_a;

    private void Start()
    {   
        game_paused = false;
    }

    private void Update()
    {
        life_a = player.GetComponent<temp_link_movement>().health;
        life_n.text = life_a.ToString() + "/6";
        rupee_a = player.GetComponent<temp_link_movement>().rupeeCount;
        rupee_n.text = rupee_a.ToString();
        key_a = player.GetComponent<temp_link_movement>().keys;
        key_n.text = key_a.ToString();
        if(player.GetComponent<Bow>().hasBow == true)
        {
            bow_icon.GetComponent<SpriteRenderer>().enabled = true;
        }



        if (game_paused == false)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
               game_paused = true;
               menu.GetComponent<SpriteRenderer>().enabled = true;
                invent.GetComponent<SpriteRenderer>().enabled = false;
                heart_icon.GetComponent<SpriteRenderer>().enabled = false;
                rupee_icon.GetComponent<SpriteRenderer>().enabled = false;
                key_icon.GetComponent<SpriteRenderer>().enabled = false;
                bow_icon.GetComponent<SpriteRenderer>().enabled = false;
                life_icon.GetComponent<SpriteRenderer>().enabled = false;

                Time.timeScale = 0;
            }
        }
        else if (game_paused == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                game_paused = false;
                menu.GetComponent<SpriteRenderer>().enabled = false;
                //menu.GetComponent<menu>().RemoveMenu();
                invent.GetComponent<SpriteRenderer>().enabled = true;
                heart_icon.GetComponent<SpriteRenderer>().enabled = true;
                rupee_icon.GetComponent<SpriteRenderer>().enabled = true;
                key_icon.GetComponent<SpriteRenderer>().enabled = true;
                life_icon.GetComponent<SpriteRenderer>().enabled = true;
                if (player.GetComponent<Bow>().hasBow == true)
                {
                    bow_icon.GetComponent<SpriteRenderer>().enabled = true;
                }


                Time.timeScale = 1;
            }
        }


    }


}
