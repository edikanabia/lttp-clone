using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    
    public GameObject active_pos;
    public GameObject disable_pos;

    // private void Awake()
    //{
    //    instance = this;
    // }

    public void CallMenu()
    {
        Vector3 act_pos_menu = active_pos.transform.position;
        transform.position = act_pos_menu;
    }

    public void RemoveMenu()
    {
        Vector3 dis_pos_menu = disable_pos.transform.position;
        transform.position = dis_pos_menu;
    }

}

        
    


