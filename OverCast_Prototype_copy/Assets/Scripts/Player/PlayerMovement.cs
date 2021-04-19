using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runspeed = 40f;
    public float horizontal_move = 0f;
    

    // Update is called once per frame
    public void Update()
    {
        //Debug.Log() -> used to print return values to console
        //get input from player
        horizontal_move = Input.GetAxisRaw("Horizontal") * runspeed;
    }

    public void FixedUpdate()
    {
        //character movement
        //move based on float value, boolean->crouch, boolean->jump
        controller.Move(horizontal_move * Time.fixedDeltaTime, false);

    }
}
