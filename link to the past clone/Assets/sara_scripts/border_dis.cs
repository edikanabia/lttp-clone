using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border_dis : MonoBehaviour
{
    public GameObject[] borderss;
    public GameObject[] decos;
    public GameObject[] low_walls;
    public static border_dis instance;
     
    
    private void Awake()
    {
         instance = this;
    }
    public void DisableCollisionsWithBorders()
    {        
        borderss = GameObject.FindGameObjectsWithTag("border");
        foreach (GameObject border in borderss)
        {
            border.GetComponent<BoxCollider2D>().enabled = false;
        }        
    }

    public void ActivateCollisionsWithBorders()
    {
        
        borderss = GameObject.FindGameObjectsWithTag("border");

        foreach (GameObject border in borderss)
        {
            border.GetComponent<BoxCollider2D>().enabled = true;
        }
        
    }

    public void DisableCollisionsWithDeco()
    {

        decos = GameObject.FindGameObjectsWithTag("deco");

        foreach (GameObject deco in decos)
        {
            deco.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    public void ActivateCollisionsWithDeco()
    {

        decos = GameObject.FindGameObjectsWithTag("deco");

        foreach (GameObject deco in decos)
        {
            deco.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    public void DisableCollisionsWithLowWalls()
    {

        low_walls = GameObject.FindGameObjectsWithTag("low_floor_wall");

        foreach (GameObject low_floor_wall in low_walls)
        {
            low_floor_wall.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    public void ActivateCollisionsWithLowWalls()
    {

        low_walls = GameObject.FindGameObjectsWithTag("low_floor_wall");

        foreach (GameObject low_floor_wall in low_walls)
        {
            low_floor_wall.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

}
