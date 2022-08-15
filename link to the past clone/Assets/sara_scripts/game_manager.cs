using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public bool game_paused = false;
    public GameObject menu;

    private void Start()
    {   
        game_paused = false;
    }

    private void Update()
    {
        
        if (game_paused == false)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
               game_paused = true;
               menu.GetComponent<menu>().CallMenu();
               Time.timeScale = 0;
            }
        }
        else if (game_paused == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                game_paused = false;
                menu.GetComponent<menu>().RemoveMenu();
                Time.timeScale = 1;
            }
        }


    }


}
