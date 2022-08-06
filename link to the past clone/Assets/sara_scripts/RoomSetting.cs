using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSetting : MonoBehaviour
{
    [HideInInspector] public Vector2 room_camera_size;
    BoxCollider2D col;
    public int room_number = 0;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        room_camera_size = col.size;
    }
}
