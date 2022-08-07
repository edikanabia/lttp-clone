using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiFairyController : MonoBehaviour
{
    public float antiFairySpeed;
    public Rigidbody2D antiFairyRB;
    private Vector2 _movement;
    private Vector2 _previousPosition;

    void Start()
    {
        _previousPosition = antiFairyRB.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
