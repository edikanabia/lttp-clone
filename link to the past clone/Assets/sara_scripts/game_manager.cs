using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public static bool game_paused = false;

    void Start()
    {
        game_paused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("enter"))
        {
            game_paused = true;
        }
    }


}
