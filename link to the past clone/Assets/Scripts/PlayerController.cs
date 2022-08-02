using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    public Rigidbody2D playerRB;
    private Vector2 _movement;

    public Animator playerAnimator;
    private Vector2 _previousPosition;


    // Start is called before the first frame update
    void Start()
    {
        _previousPosition = playerRB.position;
    }

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

    }

    //updates at time intervals 
    //(rather than by frames, 
    //so as to not tie things to framerate).
    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + _movement * playerSpeed);

        //animation
        if(playerRB.position == _previousPosition) //isn't moving
        {
            playerAnimator.SetBool("moving", false);
        }
        else
        {
            playerAnimator.SetBool("moving", true);

            if (_movement.y > 0) //down
            {
                playerAnimator.SetInteger("direction", 3);

            }

            if (_movement.x < 0) //left
            {
                playerAnimator.SetInteger("direction", 1);
            }

            if (_movement.x > 0) //right
            {
                playerAnimator.SetInteger("direction", 2);
            }

            if (_movement.y < 0) //up
            {
                playerAnimator.SetInteger("direction", 0);
            }
        }

        _previousPosition = playerRB.position;
    }
}